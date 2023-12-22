using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Organizations
{
    public class OrganizationExtraDetails:Auditable
    {
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
