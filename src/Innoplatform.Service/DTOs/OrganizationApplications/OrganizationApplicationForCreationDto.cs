using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Domain.Enums;

namespace Innoplatform.Service.DTOs.OrganizationApplications;

public class OrganizationApplicationForCreationDto
{
    public long UserId { get; set; }
    public long ProjectId { get; set; }
    public long OrganizationId { get; set; }
    public string Description { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime ApplicationDate { get; set; }
    public decimal ProposedInvestmentAmount { get; set; }
}
