using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.OrganizationProjectInvestments;

public class OrganizationProjectInvestmentForCreationDto
{
    public long UserId { get; set; }
    public long OrganizationId { get; set; }
    public long ApplicationId { get; set; }
    public long InvestmentAreaId { get; set; }
    public long InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }
    public DateTime InvestmentDate { get; set; }
}
