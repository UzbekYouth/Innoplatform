using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.Applications
{
    public class ApplicationForUpdateDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long ProjectId { get; set; }
        [Required]
        public long InvestmentId { get; set; }
        [Required]
        public long InvestmentAreaId { get; set; }
        [Required]
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
