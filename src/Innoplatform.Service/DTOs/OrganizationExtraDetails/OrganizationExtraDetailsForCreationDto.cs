using Innoplatform.Domain.Entities.Organizations;

namespace Innoplatform.Service.DTOs.OrganizationExtraDetails;

public class OrganizationExtraDetailsForCreationDto
{
    public long OrganizationId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
