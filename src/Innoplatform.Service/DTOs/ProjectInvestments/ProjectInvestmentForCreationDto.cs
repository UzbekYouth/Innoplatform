using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.ProjectInvestments
{
    public class ProjectInvestmentForCreationDto
    {
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public long ApplicationId { get; set; }
        public long IvestmentAreaId { get; set; }
        public long InvestmentId { get; set; }
        public decimal InvestmentAmount { get; set; }
    }
}
