using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Enum;

namespace Innoplatform.Domain.Entities;

public class ProjectInvestment : Auditable
{
    public  long ProjectId { get; set; }
    public long UserId { get; set; }
    public long ApplicationId { get; set; }
    public long IvestmentAreaId { get; set; }
    public long InvestmentId { get; set; }
    public decimal InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }

}
