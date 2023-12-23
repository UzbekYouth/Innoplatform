using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.ProjectInvestmentInvitations;

public class ProjectInvestmentInvitationForUpdateDto
{
    public string Title { get; set; }
    public string InvitationLetter { get; set; }
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}
