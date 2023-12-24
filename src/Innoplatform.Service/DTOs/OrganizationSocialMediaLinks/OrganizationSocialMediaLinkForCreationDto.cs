using Innoplatform.Domain.Entities.Organizations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.OrganizationSocialMediaLinks;

public class OrganizationSocialMediaLinkForCreationDto
{
    [Required]
    public long OrganizationId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    [Required]
    public string Url { get; set; }
}
