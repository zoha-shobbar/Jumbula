using Jumbula.Application.Dtos;
using Jumbula.Application.Dtos.Jwt;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices.Common;
using Jumbula.Domain.Entities;
using Jumbula.Domain.Entities.Account;

namespace Jumbula.Application.Services.EntityServices;
public interface IAccountService : IBaseService<User, SignInInputDto>
{
    Task<SingleResponse<AccessToken>> SignIn(SignInInputDto input);
    Task<SingleResponse<AccessToken>> RegisterBusiness(SignUpBusinessInputDto input);
    Task<SingleResponse<AccessToken>> RegisterParent(Guid? familyId, SignUpParentInputDto input);
    Task<SingleResponse<Student>> RegisterStudent(Guid parentId, SignUpStudentInputDto input);
}
