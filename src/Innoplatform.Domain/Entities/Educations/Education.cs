using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Educations
{
    public class Education : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
