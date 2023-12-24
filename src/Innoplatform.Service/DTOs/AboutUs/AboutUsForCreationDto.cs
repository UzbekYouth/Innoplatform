using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.AboutUses
{
    public class AboutUsForCreationDto
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
