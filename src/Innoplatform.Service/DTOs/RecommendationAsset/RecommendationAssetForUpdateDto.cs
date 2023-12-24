using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.RecommendationAsset;

public class RecommendationAssetForUpdateDto
{
    [Required]
    public long RecommendationId { get; set; }
    [Required]
    public IFormFile Media { get; set; }
}
