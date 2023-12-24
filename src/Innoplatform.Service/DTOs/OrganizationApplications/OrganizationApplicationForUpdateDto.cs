using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.OrganizationApplications;

public class OrganizationApplicationForUpdateDto
{
    [Required]
    public long UserId { get; set; }
    [Required]
    public long ProjectId { get; set; }
    [Required]
    public long OrganizationId { get; set; }
    public string? Description { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
    public decimal ProposedInvestmentAmount { get; set; }
}
