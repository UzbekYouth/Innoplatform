using Innoplatform.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Domain.Entities.About;

public class AboutUsAsset : Auditable
{
    public long AboutUsId { get; set; }
    public AboutUs AboutUs { get; set; }
    [Required]
    public string Image { get; set; }

}
