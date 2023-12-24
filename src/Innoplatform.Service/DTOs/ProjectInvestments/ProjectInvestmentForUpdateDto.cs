using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.ProjectInvestments
{
    public class ProjectInvestmentForUpdateDto
    {
        [Required]
        public long ProjectId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long ApplicationId { get; set; }
        [Required]
        public long IvestmentAreaId { get; set; }
        [Required]
        public long InvestmentId { get; set; }
        [Required]
        public decimal InvestmentAmount { get; set; }
    }
}
