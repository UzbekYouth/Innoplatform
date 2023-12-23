using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.OrganizationProjectInvestments;

public class OrganizationProjectInvestmentForUpdateDto
{
    public long InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }
    public DateTime InvestmentDate { get; set; }
}
