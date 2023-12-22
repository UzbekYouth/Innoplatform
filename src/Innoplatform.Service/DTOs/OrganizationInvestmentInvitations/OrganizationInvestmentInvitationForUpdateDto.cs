using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.OrganizationInvestmentInvitations;

public class OrganizationInvestmentInvitationForUpdateDto
{
    public long OrganizationId { get; set; }
    public long ProjectId { get; set; }
    public string Title { get; set; }
    public string InvitationLetter { get; set; }
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}
