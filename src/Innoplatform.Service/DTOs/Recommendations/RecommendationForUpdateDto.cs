using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Recommendations;

public class RecommendationForUpdateDto
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }
    public long RecommendationAreaId { get; set; }
    public string Description { get; set; }
}
