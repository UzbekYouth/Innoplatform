using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.ProjectInvestments
{
    public class ProjectInvestmentForResultDto
    {
        public long Id { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
        public Application Application { get; set; }
        public InvestmentArea InvestmentArea { get; set; }
        public Investment Investment { get; set; }
        public decimal InvestmentAmount { get; set; }
        public ProjectInvestmentStatus Status { get; set; }
    }
}
