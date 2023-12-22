using Innoplatform.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.AchievementAssets
{
    public class AchievementAssetsForCreationDto
    {
        public long AchievementId { get; set; }
        public IFormFile Media { get; set; }
    }
}
