using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.DTOs.OrganizationSocialMediaLinks;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Innoplatform.Api.Controllers.OrganizationControllers
{
    public class OrganizationSocialMediaLinksController : BaseController
    {
        private readonly IOrganizationSocialMediaLinkService _service;

        public OrganizationSocialMediaLinksController(IOrganizationSocialMediaLinkService service)
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
        public async Task<IActionResult> PostAsync([FromForm] OrganizationSocialMediaLinkForCreationDto dto)
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
        public async Task<IActionResult> PutAsync([FromForm(Name = "id")] long id, [FromBody] OrganizationSocialMediaLinkForUpdateDto dto)
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
