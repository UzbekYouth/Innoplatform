using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.InvestmentAreas;

public class InvestmentAreaForCreationDto
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }
}
