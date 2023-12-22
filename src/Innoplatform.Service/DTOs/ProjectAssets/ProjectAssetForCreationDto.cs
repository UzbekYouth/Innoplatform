using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.ProjectAssets
{
    public class ProjectAssetForCreationDto
    {
        public long ProjectId { get; set; }
        public IFormFile File { get; set; }
    }
}
