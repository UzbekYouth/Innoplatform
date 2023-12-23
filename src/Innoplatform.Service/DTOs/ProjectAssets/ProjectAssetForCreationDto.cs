using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.ProjectAssets
{
    public class ProjectAssetForCreationDto
    {
        [Required]
        public long ProjectId { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
