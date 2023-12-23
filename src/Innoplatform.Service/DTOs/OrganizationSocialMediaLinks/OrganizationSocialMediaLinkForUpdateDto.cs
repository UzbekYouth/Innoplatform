using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.OrganizationSocialMediaLinks;

public class OrganizationSocialMediaLinkForUpdateDto
{
    public long OrganizationId { get; set; }
    public string Title { get; set; }
    public IFormFile Image { get; set; }
    public string Url { get; set; }
}
