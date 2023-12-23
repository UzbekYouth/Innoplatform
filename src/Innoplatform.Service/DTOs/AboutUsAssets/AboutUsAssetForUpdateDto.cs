using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.AboutUsAssets;

public class AboutUsAssetForUpdateDto
{
    [Required]
    public IFormFile Image { get; set; }
}
