using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Enum;
using System;

namespace Innoplatform.Domain.Entities
{
    public class Application:Auditable
    {
        public long  UserId { get; set; }
        public long ProjectId {  get; set; }
        public long InvestmentId { get; set; }
        public long InvestmentAreaId { get; set; }
        public ApplicationStatus StatusApplicationStatus { get; set; }
        public decimal ProposedInvestmentAmount {  get; set; }
    }
}
