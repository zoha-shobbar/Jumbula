using Jumbula.Domain.Entities.Common;

namespace Jumbula.Domain.Entities;
public class Family : BaseEntity
{
    public Guid InsuranceId { get; set; }
    public Insurance Insurance { get; set; }

    public ICollection<Parent> Parents { get; set; }
    public ICollection<Student> Students { get; set; }
}
