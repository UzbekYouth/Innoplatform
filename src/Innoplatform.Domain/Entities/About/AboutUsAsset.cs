using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.About;

public class AboutUsAsset : Auditable
{
    public long ApouteUsId { get; set; }
    public AboutUs AboutUs { get; set; }

    public string Image { get; set; }

}
