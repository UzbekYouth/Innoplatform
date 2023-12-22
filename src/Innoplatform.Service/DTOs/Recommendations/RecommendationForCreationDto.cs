using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Recommendations;

public class RecommendationForCreationDto
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }
    public long RecomedationAreaId { get; set; }
    public string Description { get; set; }
}
