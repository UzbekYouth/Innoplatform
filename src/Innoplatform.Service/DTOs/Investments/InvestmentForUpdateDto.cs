﻿using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Investments;

public class InvestmentForUpdateDto
{
    [Required]
    public long InvestmentAreaId { get; set; }
    [Required]
    public long UserId { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? Description { get; set; }
    [Required]
    public decimal MaxInvestmentAmount { get; set; }
    [Required]
    public decimal MinInvestmentAmount { get; set; }
    public InvestmentStatus Status { get; set; }
}
