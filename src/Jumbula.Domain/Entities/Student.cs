using Jumbula.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumbula.Domain.Entities;

[Table(nameof(Student))]
public class Student : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}
