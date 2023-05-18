using Jumbula.Application.Dtos.Jwt;
using Jumbula.Application.Dtos;
using Jumbula.Application.Responses;

namespace Jumbula.Application.Services.EntityServices;
public interface IAccountService
{
    Task<SingleResponse<AccessToken>> SignIn(SignInInputDto input);
    Task<SingleResponse<AccessToken>> RegisterBusiness(SignUpBusinessInputDto input);

}
