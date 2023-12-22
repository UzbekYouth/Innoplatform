namespace Innoplatform.Service.DTOs.Applications
{
    public class ApplicationForCreationDto
    {
        public long UserId { get; set; }
        public long ProjectId { get; set; }
        public long InvestmentId { get; set; }
        public long InvestmentAreaId { get; set; }
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
