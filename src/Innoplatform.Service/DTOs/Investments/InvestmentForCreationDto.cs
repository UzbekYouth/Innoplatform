using Innoplatform.Domain.Enums;

public class InvestmentForCreationDto
{
    public long InvestmentAreaId { get; set; }

    public long UserId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    public decimal MaxInvestmentAmount { get; set; }
    public decimal MinInvestmentAmount { get; set; }
    public Status Status { get; set; }
}
