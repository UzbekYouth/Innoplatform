using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities
{
    public class AboutUs : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
