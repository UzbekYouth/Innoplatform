﻿using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Projects
{
    public class Application : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        public long InvestmentId { get; set; }
        public Investment Investment { get; set; }
        public long InvestmentAreaId { get; set; }
        public InvestmentArea InvestmentArea { get; set; }
        public ApplicationStatus Status { get; set; }
        public decimal ProposedInvestmentAmount { get; set; }
    }
}
