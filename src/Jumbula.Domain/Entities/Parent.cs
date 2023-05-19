using Jumbula.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumbula.Domain.Entities;

[Table(nameof(Parent))]
public class Parent : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Guid ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; }

    public Guid FamilyId { get; set; }
    public Family Family { get; set; }

}

