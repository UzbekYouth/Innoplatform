﻿using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.OrganizationInvestment;

public class OrganizationInvestmentForUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal MaximumInvestmentAmount { get; set; }
    public decimal MinimumInvestmentAmount { get; set; }
    public InvestmentStatus Status { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}