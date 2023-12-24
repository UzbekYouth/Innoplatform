using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Applications
{
    public class ApplicationForCreationDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long ProjectId { get; set; }
        [Required]
        public long InvestmentId { get; set; }
        [Required]
        public long InvestmentAreaId { get; set; }
        [Required]
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
