﻿using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.OrganizationInvestmentInvitations;

public class OrganizationInvestmentInvitationForCreationDto
{
    [Required]
    public long OrganizationId { get; set; }
    [Required]
    public long ProjectId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string InvitationLetter { get; set; }
    public decimal InvestmentAmount { get; set; }
    public InvitationStatus Status { get; set; }
}
