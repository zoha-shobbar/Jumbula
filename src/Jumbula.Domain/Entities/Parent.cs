using Jumbula.Domain.Entities.Account;

namespace Jumbula.Domain.Entities;
public class Parent : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public Guid ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; }
}

