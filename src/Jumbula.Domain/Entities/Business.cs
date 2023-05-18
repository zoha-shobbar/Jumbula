using Jumbula.Domain.Entities.Account;

namespace Jumbula.Domain.Entities;
public class Business : User
{
    public Guid ExternalId { get; set; }
}
