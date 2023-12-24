using Innoplatform.Domain.Enums;
using Innoplatform.Service.DTOs.Applications;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.DTOs.OrganizationProjectInvestments;

public class OrganizationProjectInvestmentForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public UserForResultDto User { get; set; }
    public long OrganizationId { get; set; }
    public ProjectForResultDto Project { get; set; }
    public long ApplicationId { get; set; }
    public ApplicationForResultDto Application { get; set; }
    public long InvestmentAreaId { get; set; }
    public InvestmentAreaForResultDto InvestmentArea { get; set; }
    public long InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }
    public DateTime InvestmentDate { get; set; }
}
