using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Projects;

public class ProjectInvestment : Auditable
{
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long ApplicationId { get; set; }
    public Application Application { get; set; }
    public long IvestmentAreaId { get; set; }
    public InvestmentArea InvestmentArea { get; set; }
    public long InvestmentId { get; set; }
    public Investment Investment { get; set; }
    public decimal InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }

}
