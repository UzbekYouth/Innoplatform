using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Image { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal AccauntBalance { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Hash { get; set; }

}
