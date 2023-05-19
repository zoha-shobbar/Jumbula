namespace Jumbula.Application.Dtos;
public class InsuranceInputDto
{
    public Guid ExternalId { get; set; }
    public string CompanyName { get; set; }
    public string PolicyNumber { get; set; }
    public string CompanyPhone { get; set; }
}
