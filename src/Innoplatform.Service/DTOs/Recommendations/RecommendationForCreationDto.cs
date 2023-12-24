﻿using Innoplatform.Domain.Entities.Recommendations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Recommendations;

public class RecommendationForCreationDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    [Required]
    public long RecommendationAreaId { get; set; }
    public string? Description { get; set; }
}
