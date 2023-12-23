using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Users;

public class UserForUpdateDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string Address { get; set; }
}
