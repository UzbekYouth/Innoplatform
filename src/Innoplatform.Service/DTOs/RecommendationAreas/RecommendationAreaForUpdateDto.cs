using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.RecommendationAreas
{
    public class RecommendationAreaForUpdateDto
    {
        [Required]
        public string Area { get; set; }
    }
}
