using AutoMapper;
using Jumbula.Application.Constants;
using Jumbula.Application.Dtos;
using Jumbula.Application.Dtos.Jwt;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices;
using Jumbula.Application.Services.EntityServices.Common;
using Jumbula.Domain.Entities;
using Jumbula.Domain.Entities.Account;
using Jumbula.Domain.Repositories.Common;
using Jumbula.Infrastructure.Services.Jwt;
using LMS.Infrastructure.Services.EntityServices.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jumbula.Infrastructure.Services.EntityServices;
public class AccountService : BaseService<User, SignInInputDto>, IAccountService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public AccountService(SignInManager<User> signInManager,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IJwtService jwtService,
        IBaseRepository<User> repository,
        IMapper mapper) : base(repository, mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<SingleResponse<AccessToken>> SignIn(SignInInputDto input)
    {
        User? user = await _userManager.FindByNameAsync(input.Email);

        if (user is null)
            return ResponseStatus.UserNotFound;

        var result = await _signInManager.PasswordSignInAsync(user, input.Password, false, false);

        if (!result.Succeeded)
            return ResponseStatus.UserNotFound;

        return await _jwtService.GenerateToken(user);
    }

    public async Task<SingleResponse<AccessToken>> RegisterBusiness(SignUpBusinessInputDto input)
    {
        var existedUser = await _userManager.FindByEmailAsync(input.Email);
        if (existedUser is not null) return ResponseStatus.AlreadyExists;

        Business business = _mapper.Map<SignUpBusinessInputDto, Business>(input);
        business.UserName = input.Email;

        var result = await _userManager.CreateAsync(business, input.Password);
        if (!result.Succeeded)
            return new(ResponseStatus.UnknownError, result.Errors.FirstOrDefault().Description);

        await AddUserToRole(business, nameof(RoleConstants.Business));

        return await _jwtService.GenerateToken(business);
    }

    public async Task<SingleResponse<AccessToken>> RegisterParent(Guid? familyId, SignUpParentInputDto input)
    {
        var existedUser = await _userManager.FindByEmailAsync(input.Email);
        if (existedUser is not null) return ResponseStatus.AlreadyExists;

        Parent parent = _mapper.Map<SignUpParentInputDto, Parent>(input);

        parent.UserName = input.Email;

        if (familyId is null)
        {
            var isInsuranceExist = GetAll<Insurance>().Where(x => x.Id == input.InsuranceId).Any();
            if (!isInsuranceExist) return ResponseStatus.InsuranceNotFound;

            if (input.InsuranceId is null) return ResponseStatus.RequiredDataNotFilled;
            Family family = new() { InsuranceId = input.InsuranceId!.Value };

            await Create<Family>(family);
            parent.FamilyId = family.Id;
        }
        else
        {
            parent.FamilyId = familyId.Value;
        }

        var result = await _userManager.CreateAsync(parent, input.Password);
        if (!result.Succeeded)
            return new(ResponseStatus.UnknownError, result.Errors.FirstOrDefault().Description);

        await AddUserToRole(parent, nameof(RoleConstants.Parent));

        return await _jwtService.GenerateToken(parent);
    }

    public async Task<SingleResponse<AccessToken>> RegisterStudent(Guid parentId, SignUpStudentInputDto input)
    {
        Parent? parent = GetAll<Parent>().Where(x => x.Id == parentId).FirstOrDefault();
        if (parent is null) return ResponseStatus.UserNotFound;

        var existedUser = await _userManager.FindByEmailAsync(input.Email);
        if (existedUser is not null) return ResponseStatus.AlreadyExists;

        Student student = _mapper.Map<SignUpStudentInputDto, Student>(input);

        student.UserName = input.Email;
        student.FamilyId = parent.FamilyId;


        var result = await _userManager.CreateAsync(student, input.Password);
        if (!result.Succeeded)
            return new(ResponseStatus.UnknownError, result.Errors.FirstOrDefault().Description);

        await AddUserToRole(student, nameof(RoleConstants.Parent));

        return await _jwtService.GenerateToken(student);
    }

    private async Task AddUserToRole(User user, string roleName)
    {
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
            await _roleManager.CreateAsync(new Role { Name = roleName, NormalizedName = roleName.Normalize() });

        var result = await _userManager.AddToRoleAsync(user, roleName);
    }
}
