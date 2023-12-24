using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.Projects
{
    public class ProjectForCreationDto
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
    }
}
