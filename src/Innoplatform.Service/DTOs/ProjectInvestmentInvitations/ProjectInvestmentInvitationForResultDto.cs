﻿using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.ProjectInvestmentInvitations;

public class ProjectInvestmentInvitationForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; } // Investor
    public long ProjectId { get; set; }
    public string Title { get; set; }
    public string InvitationLetter { get; set; }
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}