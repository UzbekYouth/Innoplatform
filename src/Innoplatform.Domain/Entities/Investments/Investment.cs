﻿using Innoplatform.Domain.Commons;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Domain.Entities.Investments;

public class Investment : Auditable
{
    public long InvestmentAreaId { get; set; }
    public InvestmentArea InvestmentArea { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public string Title { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? Description { get; set; }
    public decimal MaxInvestmentAmount { get; set; }
    public decimal MinInvestmentAmount { get; set; }
    public InvestmentStatus Status { get; set; }

}
