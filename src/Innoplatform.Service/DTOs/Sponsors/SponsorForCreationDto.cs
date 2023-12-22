using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Sponsors;

public class SponsorForCreationDto
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }
    public string Description { get; set; }
}
