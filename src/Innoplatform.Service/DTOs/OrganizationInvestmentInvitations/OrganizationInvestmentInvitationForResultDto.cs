using Innoplatform.Domain.Enums;
using Innoplatform.Service.DTOs.Organizations;
using Innoplatform.Service.DTOs.Projects;

namespace Innoplatform.Service.DTOs.OrganizationInvestmentInvitations;

public class OrganizationInvestmentInvitationForResultDto
{
    public long Id { get; set; }
    public long OrganizationId { get; set; }
    public OrganizationForResultDto Organization { get; set; }
    public long ProjectId { get; set; }
    public ProjectForResultDto Project { get; set; }
    public string Title { get; set; }
    public string InvitationLetter { get; set; }
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}
