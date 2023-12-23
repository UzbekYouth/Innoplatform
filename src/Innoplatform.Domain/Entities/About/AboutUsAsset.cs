using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.About;

public class AboutUsAsset : Auditable
{
    public long AboutUsId { get; set; }
    public AboutUs AboutUs { get; set; }
    public string Image { get; set; }

}
