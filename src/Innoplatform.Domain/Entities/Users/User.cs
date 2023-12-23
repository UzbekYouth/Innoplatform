using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Image { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal AccountBalance { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Salt { get; set; }
    public Roles Role { get; set; } = Roles.User;

}
