using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.Investments;

public class InvestmentForUpdateDto
{
    public long InvestmentAreaId { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal MaxInvestmentAmount { get; set; }
    public decimal MinInvestmentAmount { get; set; }
    public Status Status { get; set; }
}
