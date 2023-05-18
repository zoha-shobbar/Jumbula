using Jumbula.Application.Dtos.Jwt;
using Jumbula.Domain.Entities.Account;

namespace Jumbula.Infrastructure.Services.Jwt;
public interface IJwtService
{
    Task<AccessToken> GenerateToken(User user);
}