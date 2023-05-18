using Jumbula.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace Jumbula.Domain.Entities.Account;
public class Role : IdentityRole<Guid>, IBaseEntity
{
}
