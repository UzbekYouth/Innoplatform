using Innoplatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.AchievementAssets
{
    public class AchievementAssetsForUpdateDto
    {
        public long AchievementId { get; set; }
        public string Media { get; set; }
    }
}
