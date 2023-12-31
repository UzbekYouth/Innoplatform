﻿using Innoplatform.Service.DTOs.RecommendationAreas;
using Innoplatform.Service.DTOs.RecommendationAsset;
using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Recommendations;

public class RecommendationForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public long RecommendationAreaId { get; set; }
    public RecommendationAreaForResultDto RecommendationArea { get; set; }
    public string Description { get; set; }
    public IEnumerable<RecommendationAssetForResultDto> RecommendationAssets { get; set; }

}
