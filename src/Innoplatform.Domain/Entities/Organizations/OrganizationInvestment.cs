using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Organizations
{
    public class OrganizationInvestment:Auditable
    {
        public string Title { get; set; }
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string InvestmentArea { get; set; }
        public string? Description { get; set; }
        public decimal MaximumInvestmentAmount { get; set; }
        public decimal MinimumInvestmentAmount { get; set; }
        public InvestmentStatus Status { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
