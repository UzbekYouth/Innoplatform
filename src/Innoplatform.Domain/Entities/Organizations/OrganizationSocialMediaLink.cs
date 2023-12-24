using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Organizations
{
    public class OrganizationSocialMediaLink:Auditable
    {
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
