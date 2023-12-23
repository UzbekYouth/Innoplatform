using Innoplatform.Domain.Entities.Achievments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.AchievementAssets
{
    public class AchievmentAssetsForResultDto
    {
        public long Id { get; set; }
        public Achievement Achievement { get; set; }
        public string Media { get; set; }
    }
}
