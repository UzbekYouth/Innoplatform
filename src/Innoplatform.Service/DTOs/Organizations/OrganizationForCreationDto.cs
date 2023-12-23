using Innoplatform.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Organizations;

public class OrganizationForCreationDto
{
    public string Name { get; set; }
    public IFormFile ImagePath { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string CallCenter { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
}
