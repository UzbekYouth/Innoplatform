using Innoplatform.Domain.Enums;
using Innoplatform.Service.DTOs.Organizations;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.DTOs.OrganizationApplications;

public class OrganizationApplicationForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public UserForResultDto User { get; set; }
    public long ProjectId { get; set; }
    public ProjectForResultDto Project { get; set; }
    public long OrganizationId { get; set; }
    public OrganizationForResultDto Organization { get; set; }
    public string Description { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime ApplicationDate { get; set; }
    public decimal ProposedInvestmentAmount { get; set; }
}
