using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.Projects
{
    public class ProjectForResultDto
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FundingGoal { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public decimal CurrentFunding { get; set; }
        public decimal ExpectedFunding { get; set; }
        public decimal Rating { get; set; }
    }
}
