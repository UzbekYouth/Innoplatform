﻿using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Achievments
{
    public class AchievementAsset : Auditable
    {
        public long AchievementId { get; set; }
        public Achievement Achievement { get; set; }
        public string Media { get; set; }
    }
}
