using Jumbula.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumbula.Domain.Entities;

[Table(nameof(Student))]
public class Student : User
{
    public string FirstName1 { get; set; }
    public string LastName1 { get; set; }
    public string Gender1 { get; set; }
    public DateTime DateOfBirth1 { get; set; }
}
