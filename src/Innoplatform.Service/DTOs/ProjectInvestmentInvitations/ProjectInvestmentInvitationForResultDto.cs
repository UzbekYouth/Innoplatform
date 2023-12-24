using Innoplatform.Domain.Enums;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.DTOs.ProjectInvestmentInvitations;

public class ProjectInvestmentInvitationForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; } // Investor
    public UserForResultDto User { get; set; }
    public long ProjectId { get; set; }
    public ProjectForResultDto Project { get; set; }
    public string Title { get; set; }
    public string InvitationLetter { get; set; }
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}
