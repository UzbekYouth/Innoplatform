using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.OrganizationExtraDetails
{
    public class OrganizationExtraDetailForCreationDto
    {
        [Required]
        public long OrganizationId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
