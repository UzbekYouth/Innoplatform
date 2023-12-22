using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.Applications
{
    public class ApplicationForResultDto
    {
        public long Id { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public Investment Investment { get; set; }
        public InvestmentArea InvestmentArea { get; set; }
        public ApplicationStatus Status { get; set; }
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
