using Innoplatform.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Organizations;

public class OrganizationForUpdateDto
{
    public string Name { get; set; }
    public IFormFile ImagePath { get; set; }
    public string Description { get; set; }
    public string CallCenter { get; set; }
    public string Address { get; set; }
    public Roles Role { get; set; }
}
