using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.AboutUsAssets;

public class AboutUsAssetForUpdateDto
{
    public long ApouteUsId { get; set; }
    public IFormFile Image { get; set; }
}
