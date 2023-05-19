using Jumbula.Domain.Entities.Common;

namespace Jumbula.Domain.Entities;
public class Insurance : BaseEntity
{
    public Guid ExternalId { get; set; }
    public string CompanyName { get; set; }
    public string PolicyNumber { get; set; }
    public string CompanyPhone { get; set; }

    //public ICollection<Family> Families { get; set; }
}
