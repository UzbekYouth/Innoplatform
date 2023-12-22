using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.RecommendationAsset;

public class RecommendationAssetForResultDto
{
    public long Id { get; set; }
    public long RecommendationId { get; set; }
    public IFormFile Media { get; set; }
}
