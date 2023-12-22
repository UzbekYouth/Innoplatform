using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.Projects
{
    public class ProjectForCreationDto
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FundingGoal { get; set; }
        public decimal CurrentFunding { get; set; }
        public decimal ExpectedFunding { get; set; }
    }
}
