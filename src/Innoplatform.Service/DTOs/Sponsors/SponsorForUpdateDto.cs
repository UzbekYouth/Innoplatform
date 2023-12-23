using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Sponsors;

public class SponsorForUpdateDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    public string Description { get; set; }
}
