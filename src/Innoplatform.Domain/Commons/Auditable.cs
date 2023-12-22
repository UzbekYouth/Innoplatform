namespace Innoplatform.Domain.Commons
{
    public class Auditable
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
<<<<<<< HEAD
        public DateTime UpdatedAt { get; set;}
        public bool IsDeleted { get; set; } = false; 
=======
        public DateTime? UpdatedAt { get; set;}
>>>>>>> b9ab772b2cd8fc51a057e05a43c6c76bb2dd50ae
    }
}
