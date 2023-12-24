using Innoplatform.Service.DTOs.Organizations;

namespace Innoplatform.Service.DTOs.OrganizationExtraDetails;

public class OrganizationExtraDetailForResultDto
{
    public long Id { get; set; }
    public long OrganizationId { get; set; }
<<<<<<< HEAD
    public OrganizationForResultDto Organization {  get; set; } 
=======
    public OrganizationForResultDto Organization { get; set; }
>>>>>>> cf05122a3f1011c7eb9a6a69e84b13df35e1d55d
    public string Title { get; set; }
    public string Description { get; set; }
}
