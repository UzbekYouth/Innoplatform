using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Users;

public class UserForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IFormFile Image { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
}
