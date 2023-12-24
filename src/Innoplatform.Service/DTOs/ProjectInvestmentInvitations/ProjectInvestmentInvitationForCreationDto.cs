using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.ProjectInvestmentInvitations;

public class ProjectInvestmentInvitationForCreationDto
{
    [Required]
    public long UserId { get; set; } // Investor
    [Required]
    public long ProjectId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string InvitationLetter { get; set; }
    [Required]
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}
