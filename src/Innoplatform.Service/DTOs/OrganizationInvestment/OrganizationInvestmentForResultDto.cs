using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.OrganizationInvestment;

public class OrganizationInvestmentForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public long OrganizationId { get; set; }
    public string InvestmentArea { get; set; }
    public string Description { get; set; }
    public decimal MaximumInvestmentAmount { get; set; }
    public decimal MinimumInvestmentAmount { get; set; }
    public InvestmentStatus Status { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
