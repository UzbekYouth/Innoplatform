using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.About
{
    public class AboutUs : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
