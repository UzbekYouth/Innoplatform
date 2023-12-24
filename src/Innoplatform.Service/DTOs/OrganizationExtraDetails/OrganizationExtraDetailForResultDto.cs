using Innoplatform.Service.DTOs.Organizations;

namespace Innoplatform.Service.DTOs.OrganizationExtraDetails;

public class OrganizationExtraDetailForResultDto
{
    public long Id { get; set; }
    public long OrganizationId { get; set; }
    public OrganizationForResultDto Organization { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
