using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.Investments;

public class InvestmentForResultDto
{
    public long Id { get; set; }
    public long InvestmentAreaId { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Description { get; set; }
    public decimal MaxInvestmentAmount { get; set; }
    public decimal MinInvestmentAmount { get; set; }
    public Status Status { get; set; }
}
