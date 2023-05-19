namespace Jumbula.Application.Dtos;
public class SignUpStudentInputDto
{
    public string Email { get; set; }
    public string Password { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ContactInfoInputDto ContactInfo { get; set; }
}
