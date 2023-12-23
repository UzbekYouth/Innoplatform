using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.AboutUsAssets;

public class AboutUsAssetForUpdateDto
{
    public IFormFile Image { get; set; }
}
