using Innoplatform.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.RecommendationAsset;

public class RecommendationAssetForCreationDto
{
    [Required]
    public long RecommendationId { get; set; }
    [Required]
    public IFormFile Media { get; set; }
}
