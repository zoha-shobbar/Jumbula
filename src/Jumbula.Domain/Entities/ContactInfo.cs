using Jumbula.Domain.Entities.Common;

namespace Jumbula.Domain.Entities;
public class ContactInfo : BaseEntity
{
    public string PrimaryPhone { get; set; }
    public string AlternatePhone { get; set; }

    public Address Address { get; set; }
}
