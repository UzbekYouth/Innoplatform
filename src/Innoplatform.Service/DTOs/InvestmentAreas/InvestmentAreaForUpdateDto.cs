using Microsoft.AspNetCore.Http;

namespace Innoplatform.Service.DTOs.InvestmentAreas;

public class InvestmentAreaForUpdateDto
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }
}
