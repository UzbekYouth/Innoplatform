using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.Educations;
using Innoplatform.Service.DTOs.RecommendationAreas;
using Innoplatform.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.RecommendationControllers;

public class RecommendationAreaController : BaseController
{
    private readonly IRecommendationAreaService _service;

    public RecommendationAreaController(IRecommendationAreaService service)
    {
        _service = service;
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
    public async Task<IActionResult> AddAsync([FromBody] RecommendationAreaForCreationDto dto)
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
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long id, [FromBody] RecommendationAreaForUpdateDto dto)
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
