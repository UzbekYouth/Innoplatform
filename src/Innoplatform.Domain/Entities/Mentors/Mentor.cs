using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Mentors
{
    public class Mentor : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
    }
}
