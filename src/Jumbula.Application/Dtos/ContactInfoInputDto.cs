namespace Jumbula.Application.Dtos;
public class ContactInfoInputDto
{
    public AddressInputDto Address { get; set; }

    public string PrimaryPhone { get; set; }
    public string AlternatePhone { get; set; }
}
