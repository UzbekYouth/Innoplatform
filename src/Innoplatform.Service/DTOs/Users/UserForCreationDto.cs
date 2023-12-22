using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IFormFile Image { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal AccountBalance { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}
