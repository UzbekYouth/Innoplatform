using Innoplatform.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Organizations;

public class OrganizationForCreationDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public IFormFile ImagePath { get; set; }
    public string? Description { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public string? CallCenter { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string? UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Address { get; set; }
}
