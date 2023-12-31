﻿using Innoplatform.Api.Models;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Educations;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.Interfaces.IInvestmentServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.InvestmentControllers;

public class InvestmentsController : BaseController
{
    private readonly IInvestmentService _service;

    public InvestmentsController(IInvestmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery]PaginationParams @params)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.GetAllAsync(@params)
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
    public async Task<IActionResult> AddAsync([FromBody] InvestmentForCreationDto dto)
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
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long id, [FromBody] InvestmentForUpdateDto dto)
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
    public async Task<IActionResult> DeleteAsync( [FromRoute(Name = "id")] long id)
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
