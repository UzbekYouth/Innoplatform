using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.Applications
{
    public class ApplicationForUpdateDto
    {
        public long UserId { get; set; }
        public long ProjectId { get; set; }
        public long InvestmentId { get; set; }
        public long InvestmentAreaId { get; set; }
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
