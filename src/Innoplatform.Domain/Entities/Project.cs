using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class Project :Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long ProjectAssetId { get; set; }
    public ProjectAsset ProjectAsset { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FundingGoal { get; set; }
    public decimal CurrentFunding { get; set; }
    public decimal ExpectedFunding { get; set; }
    public DateTime ExpectedEndDate { get; set; }
}
