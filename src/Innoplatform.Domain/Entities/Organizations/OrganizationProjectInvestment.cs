using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Organizations
{
    public class OrganizationProjectInvestment : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public long ApplicationId { get; set; }
        public Application Application { get; set; }
        public long InvestmentAreaId { get; set; }
        public InvestmentArea Investment { get; set; }
        public long InvestmentAmount { get; set; }
        public ProjectInvestmentStatus Status { get; set; }
        public DateTime InvestmentDate { get; set; }
    }
}
