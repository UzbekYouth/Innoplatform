using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class Recommendation : Auditable
{
    public string Title { get; set; }
    public string Image { get; set; }

    public long RecomedationAreaId { get; set; }
    public RecommendationArea RecommendationArea { get; set; }

    public string Description { get; set; }
}
