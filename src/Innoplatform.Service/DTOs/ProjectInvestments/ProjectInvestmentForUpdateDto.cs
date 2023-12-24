using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.ProjectInvestments
{
    public class ProjectInvestmentForUpdateDto
    {
        [Required]
        public decimal InvestmentAmount { get; set; }
    }
}
