using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Recommendations;

public class RecommendationAsset : Auditable
{
    public long RecommendationId { get; set; }
    public Recommendation Recommendation { get; set; }

    public string Media { get; set; }
}
