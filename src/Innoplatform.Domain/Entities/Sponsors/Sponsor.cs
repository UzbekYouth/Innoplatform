using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Sponsors;

public class Sponsor : Auditable
{
    public string Title { get; set; }
    public string Image { get; set; }
    public string? Description { get; set; }
}
