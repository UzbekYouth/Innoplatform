using Innoplatform.Service.DTOs.Organizations;
using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.OrganizationSocialMediaLinks;

public class OrganizationSocialMediaLinkForResultDto
{
    public long Id { get; set; }
    public long OrganizationId { get; set; }
    public OrganizationForResultDto Organization { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Url { get; set; }
}
