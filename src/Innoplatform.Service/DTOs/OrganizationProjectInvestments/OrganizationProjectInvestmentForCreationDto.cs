using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.OrganizationProjectInvestments;

public class OrganizationProjectInvestmentForCreationDto
{
    [Required]
    public long UserId { get; set; }
    [Required]
    public long OrganizationId { get; set; }
    [Required]
    public long ApplicationId { get; set; }
    [Required]
    public long InvestmentAreaId { get; set; }
    [Required]
    public long InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }
    public DateTime InvestmentDate { get; set; }
}
