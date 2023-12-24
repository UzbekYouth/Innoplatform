using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Achievments
{
    public class Achievement : Auditable
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public IEnumerable<AchievementAsset> AchievementAssets { get; set; }
    }
}
