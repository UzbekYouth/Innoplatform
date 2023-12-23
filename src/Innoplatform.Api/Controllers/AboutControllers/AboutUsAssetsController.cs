using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.Interfaces.IAboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.AboutControllers;

public class AboutUsAssetsController : BaseController
{
    private readonly IAboutUsAssetService _aboutUsAssetsService;

    public AboutUsAssetsController(IAboutUsAssetService aboutUsAssetsService)
    {
        _aboutUsAssetsService = aboutUsAssetsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsAssetsService.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsAssetsService.GetByIdAsync(Id)
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm] AboutUsAssetForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsAssetsService.AddAsync(dto)
        };
        return Ok(response);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long Id, [FromForm] AboutUsAssetForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsAssetsService.ModifyAsync(Id, dto)
        };
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _aboutUsAssetsService.RemoveAsync(Id)
        };
        return Ok(response);
    }
}
