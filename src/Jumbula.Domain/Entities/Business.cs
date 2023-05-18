using Jumbula.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumbula.Domain.Entities;

[Table(nameof(Business))]
public class Business : User
{
    public Guid ExternalId { get; set; }
}
