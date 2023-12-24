using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.ProjectInvestmentInvitations;

public class ProjectInvestmentInvitationForUpdateDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string InvitationLetter { get; set; }
    [Required]
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}
