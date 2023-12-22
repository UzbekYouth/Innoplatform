using Innoplatform.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.RecommendationAsset;

public class RecommendationAssetForCreationDto
{
    public long RecommendationId { get; set; }
    public IFormFile Media { get; set; }
}
