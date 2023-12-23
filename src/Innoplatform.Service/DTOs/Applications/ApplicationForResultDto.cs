using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.DTOs.Applications
{
    public class ApplicationForResultDto
    {
        public long Id { get; set; }
        public UserForResultDto User { get; set; }
        public ProjectForResultDto Project { get; set; }
        public InvestmentForResultDto Investment { get; set; }
        public InvestmentAreaForResultDto InvestmentArea { get; set; }
        public ApplicationStatus Status { get; set; }
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
