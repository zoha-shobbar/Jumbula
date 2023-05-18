using Jumbula.Domain.Entities.Common;

namespace Jumbula.Domain.Entities;
public class Address : BaseEntity
{
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}
