using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Educations;

public class EducationForCreationDto
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    [Required]
    public string PhoneNumber { get; set; }

    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
