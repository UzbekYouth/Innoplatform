using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.RecommendationAsset;

public class RecommendationAssetForUpdateDto
{
    public long RecommendationId { get; set; }
    public IFormFile Media { get; set; }
}
