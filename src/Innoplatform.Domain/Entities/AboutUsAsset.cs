using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class AboutUsAsset : Auditable
{
    public long AbouteUsId { get; set; }
    public AboutUs AboutUs { get; set; }

    public string Image { get; set; }

}
