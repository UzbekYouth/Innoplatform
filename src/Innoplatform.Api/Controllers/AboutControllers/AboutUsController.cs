using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.Interfaces.IAboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.AboutControllers;

public class AboutUsController : BaseController
{
    private readonly IAboutUsService _aboutUsService;

    public AboutUsController(IAboutUsService aboutUsService)
    {
        _aboutUsService = aboutUsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsService.GetAllAsync()
        };
        return Ok(response);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsService.GetByIdAsync(Id)
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AboutUsForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsService.AddAsync(dto)
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsService.RemoveAsync(Id)
        };
        return Ok(response);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long Id, [FromBody] AboutUsForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsService.ModifyAsync(Id, dto)
        };
        return Ok(response);
    }
}
