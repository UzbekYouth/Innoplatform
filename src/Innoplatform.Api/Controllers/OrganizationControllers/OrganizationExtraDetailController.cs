﻿using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.DTOs.OrganizationExtraDetails;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Innoplatform.Api.Controllers.OrganizationControllers
{
    public class OrganizationExtraDetailController : BaseController
    {
        private readonly IOrganizationExtraDetailService _service;

        public OrganizationExtraDetailController(IOrganizationExtraDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.GetAllAsync()
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
                Data = await _service.GetByIdAsync(Id)
            };
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrganizationExtraDetailForCreationDto dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.AddAsync(dto)
            };
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.RemoveAsync(id)
            };
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] OrganizationExtraDetailForUpdateDto dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.ModifyAsync(id, dto)
            };
            return Ok(response);
        }
    }
}
