using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.Recommendations;

public class RecommendationForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public long RecomedationAreaId { get; set; }
    public string Description { get; set; }
}
