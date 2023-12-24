using Innoplatform.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Organizations;

public class OrganizationForUpdateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public IFormFile ImagePath { get; set; }
    public string? Description { get; set; }
    public string? CallCenter { get; set; }
    [Required]
    public string Address { get; set; }
}
