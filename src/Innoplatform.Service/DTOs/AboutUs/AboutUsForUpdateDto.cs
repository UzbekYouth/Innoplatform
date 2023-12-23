using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.AboutUses
{
    public class AboutUsForUpdateDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
