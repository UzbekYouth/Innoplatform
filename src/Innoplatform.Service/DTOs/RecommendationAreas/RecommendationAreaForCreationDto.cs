using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.RecommendationAreas
{
    public class RecommendationAreaForCreationDto
    {
        [Required]
        public string Area { get; set; }
    }
}
