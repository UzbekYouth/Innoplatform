using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.Interfaces.IAchievmentServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.AchievmentControllers;

public class AchievmentsController : BaseController
{
    private readonly IAchievmentService _achievmentService;

    public AchievmentsController(IAchievmentService achievmentService)
    {
        _achievmentService = achievmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _achievmentService.GetAllAsync()
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
            Data = await _achievmentService.GetByIdAsync(id)
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AchievementForCreationDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _achievmentService.AddAsync(dto)
        };
        return Ok(response);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long id, [FromBody] AchievementForUpdateDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _achievmentService.ModifyAsync(id, dto)
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
            Data = await _achievmentService.RemoveAsync(id)
        };
        return Ok(response);
    }

}
