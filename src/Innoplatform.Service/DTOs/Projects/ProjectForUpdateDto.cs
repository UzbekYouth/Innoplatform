using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Projects
{
    public class ProjectForUpdateDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string FundingGoal { get; set; }
        public decimal CurrentFunding { get; set; }
        public decimal ExpectedFunding { get; set; }
        public decimal Rating { get; set; }
    }
}
