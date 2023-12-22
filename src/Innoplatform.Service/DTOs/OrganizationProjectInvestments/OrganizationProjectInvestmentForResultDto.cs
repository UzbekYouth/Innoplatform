using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.OrganizationProjectInvestments;

public class OrganizationProjectInvestmentForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long OrganizationId { get; set; }
    public long ApplicationId { get; set; }
    public long InvestmentAreaId { get; set; }
    public long InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }
    public DateTime InvestmentDate { get; set; }
}
