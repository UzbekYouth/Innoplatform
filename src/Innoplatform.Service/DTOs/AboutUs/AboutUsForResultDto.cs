using Innoplatform.Service.DTOs.AboutUsAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.AboutUses
{
    public class AboutUsForResultDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<AboutUsAssetForResultDto> AboutUsAssets { get; set; }
    }
}
