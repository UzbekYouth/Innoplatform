using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Organizations
{
    public class OrganizationInvestmentInvitation:Auditable
    {
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        public string Title { get; set; }
        public string InvitationLetter { get; set; }
        public decimal InvestmentAmount { get; set; }
        public InvitationStatus Status { get; set; }
    }
}
