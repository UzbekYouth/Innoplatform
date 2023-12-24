using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;
using Innoplatform.Service.DTOs.Applications;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.DTOs.ProjectInvestments
{
    public class ProjectInvestmentForResultDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public ProjectForResultDto Project { get; set; }
        public long UserId { get; set; }
        public UserForResultDto User { get; set; }
        public long ApplicationId { get; set; }
        public ApplicationForResultDto Application { get; set; }
        public long InvestmentAreaId { get; set; }
        public InvestmentAreaForResultDto InvestmentArea { get; set; }
        public long InvestmentId { get; set; }
        public InvestmentForResultDto Investment { get; set; }
        public decimal InvestmentAmount { get; set; }
        public ProjectInvestmentStatus Status { get; set; }
    }
}
