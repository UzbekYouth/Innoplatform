using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Enums;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.DTOs.Investments;

public class InvestmentForResultDto
{
    public long Id { get; set; }
    public InvestmentAreaForResultDto InvestmentArea { get; set; }
    public UserForResultDto User { get; set; }
    public string Title { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Description { get; set; }
    public decimal MaxInvestmentAmount { get; set; }
    public decimal MinInvestmentAmount { get; set; }
    public InvestmentStatus Status { get; set; }
}
