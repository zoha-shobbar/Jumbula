using Jumbula.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace Jumbula.Domain.Entities.Account;
public class User : IdentityUser<Guid>, IBaseEntity
{
}
