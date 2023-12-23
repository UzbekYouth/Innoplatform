using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.AboutUsAssets;

public class AboutUsAssetForCreationDto
{
    [Required]
    public long AboutUsId { get; set; }

    [Required]
    public IFormFile Image { get; set; }
}
