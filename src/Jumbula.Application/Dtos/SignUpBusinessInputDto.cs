namespace Jumbula.Application.Dtos;
public class SignUpBusinessInputDto
{
    public string Email { get; set; }
    public string Password { get; set; }

    public Guid ExternalId { get; set; }

}
