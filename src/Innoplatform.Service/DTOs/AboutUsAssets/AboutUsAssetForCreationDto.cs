using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.AboutUsAssets;

public class AboutUsAssetForCreationDto
{
    public long AbouteUsId { get; set; }
    public IFormFile Image { get; set; }
}
