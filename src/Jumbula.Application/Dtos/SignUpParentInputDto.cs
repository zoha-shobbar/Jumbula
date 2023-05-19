namespace Jumbula.Application.Dtos;
public class SignUpParentInputDto
{
    public Guid? InsuranceId { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ContactInfoInputDto ContactInfo { get; set; }
}
