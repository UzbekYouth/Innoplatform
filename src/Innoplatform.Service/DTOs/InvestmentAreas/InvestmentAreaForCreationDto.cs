using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Service.DTOs.InvestmentAreas;

public class InvestmentAreaForCreationDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public IFormFile Image { get; set; }
}
