using Innoplatform.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.AchievementAssets
{
    public class AchievementAssetsForUpdateDto
    {
        [Required]
        public long AchievementId { get; set; }
        [Required]
        public IFormFile Media { get; set; }
    }
}
