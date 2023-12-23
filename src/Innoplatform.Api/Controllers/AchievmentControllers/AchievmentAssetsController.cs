using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.Interfaces.IAchievmentServices;
using Innoplatform.Service.Services.AchievmentServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.AchievmentControllers;

public class AchievmentAssetsController : BaseController
{
    private readonly IAchievementAssetService _service;

    public AchievmentAssetsController(IAchievementAssetService achievmentAssetService)
    {
        _service = achievmentAssetService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.GetAllAsync()
        };
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.GetByIdAsync(id)
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm] AchievmentAssetsForCreationDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        };
        return Ok(response);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long id, [FromForm] AchievementAssetsForUpdateDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(id, dto)
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(id)
        };
        return Ok(response);
    }
}
