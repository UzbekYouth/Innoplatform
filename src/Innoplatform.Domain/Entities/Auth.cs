using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class Auth : Auditable
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
