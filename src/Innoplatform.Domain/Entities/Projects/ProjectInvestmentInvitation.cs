using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Projects
{
    public class ProjectInvestmentInvitation
    {
        public long UserId { get; set; } // Investor
        public User User { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        public string Title { get; set; }
        public string InvitationLetter { get; set; }
        public decimal InvestmentAmount { get; set; }
        public InvitationStatus Status { get; set; }
    }
}
