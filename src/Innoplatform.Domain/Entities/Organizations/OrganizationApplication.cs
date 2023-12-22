using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Organizations
{
    public class OrganizationApplication:Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Description { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
