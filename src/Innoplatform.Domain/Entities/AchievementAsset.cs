using Innoplatform.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Domain.Entities
{
    public  class AchievementAsset : Auditable
    {
        public long AchievementId { get; set; }
        public Achievement Achievement { get; set; }
        public string Media {  get; set; }
    }
}
