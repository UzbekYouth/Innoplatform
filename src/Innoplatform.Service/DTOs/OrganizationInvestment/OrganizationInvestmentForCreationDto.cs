using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.OrganizationInvestment;

public class OrganizationInvestmentForCreationDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public long OrganizationId { get; set; }
    [Required]
    public string InvestmentArea { get; set; }
    public string? Description { get; set; }
    [Required]
    public decimal MaximumInvestmentAmount { get; set; }
    [Required]
    public decimal MinimumInvestmentAmount { get; set; }
    public InvestmentStatus Status { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
}
