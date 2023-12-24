using Innoplatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.OrganizationProjectInvestments;

public class OrganizationProjectInvestmentForUpdateDto
{
    [Required]
    public long InvestmentAmount { get; set; }
    public ProjectInvestmentStatus Status { get; set; }
    public DateTime InvestmentDate { get; set; }
}
