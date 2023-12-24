using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Recommendations;

public class Recommendation : Auditable
{
    public string Title { get; set; }
    public string Image { get; set; }
    public long RecommendationAreaId { get; set; }
    public RecommendationArea RecommendationArea { get; set; }
    public string? Description { get; set; }
    public IEnumerable<RecommendationAsset> RecommendationAssets { get; set; }
}
