using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Assets
{
    public class AssetForCreationDto
    {
        public string FolderPath { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
