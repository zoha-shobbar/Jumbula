using Jumbula.Domain.Entities.Common;
using System.Reflection.Metadata.Ecma335;

namespace Jumbula.Domain.Entities;
public class Family : BaseEntity
{
    public Guid FamilyId { get; set; }
    public Insurance Insurance { get; set; }
}
