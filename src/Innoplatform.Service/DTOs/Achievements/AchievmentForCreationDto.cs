using Innoplatform.Domain.Entities.Achievments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.AchievementAssets
{
    public class AchievmentForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
