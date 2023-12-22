using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Educations;

public class EducationForCreationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public string PhoneNumber { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
