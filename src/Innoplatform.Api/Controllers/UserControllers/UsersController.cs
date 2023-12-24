using Innoplatform.Api.Models;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Users;
using Innoplatform.Service.Interfaces.IUserServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.UserControllers;

public class UsersController : BaseController
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
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
    public async Task<IActionResult> AddAsync([FromForm] UserForCreationDto dto)
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
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long id, [FromForm] UserForUpdateDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(id, dto)
        };
        return Ok(response);
    }

    [HttpPut("ChangePassword/{id}")]
    public async Task<IActionResult> PutPasswordAsync([FromRoute(Name = "id")] long Id, [FromForm] UserPasswordForChangeDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ChangePasswordAsync(Id, dto)
        });

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
