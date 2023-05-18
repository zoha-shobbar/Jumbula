using AutoMapper;
using Jumbula.Application.Constants;
using Jumbula.Application.Dtos;
using Jumbula.Application.Dtos.Jwt;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices;
using Jumbula.Domain.Entities;
using Jumbula.Domain.Entities.Account;
using Jumbula.Infrastructure.Services.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jumbula.Infrastructure.Services.EntityServices;
public class AccountService : IAccountService
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
        IMapper mapper)
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
            return new(ResponseStatus.UnknownError,result.Errors.FirstOrDefault().Description);

        await AddUserToRole(business, nameof(RoleConstants.Business));

        return await _jwtService.GenerateToken(business);
    }


    private async Task AddUserToRole(User user, string roleName)
    {
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
            await _roleManager.CreateAsync(new Role { Name = roleName, NormalizedName = roleName.Normalize() });

        var result = await _userManager.AddToRoleAsync(user, roleName);
    }
}
