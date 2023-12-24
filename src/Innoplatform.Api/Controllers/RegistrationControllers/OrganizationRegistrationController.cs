using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.Registrations.UserRegistrations;
using Innoplatform.Service.DTOs.Registrations;
using Microsoft.AspNetCore.Mvc;
using Innoplatform.Service.Interfaces.IRegistrationServices;
using Innoplatform.Service.DTOs.Registrations.OrganizationRegistrations;

namespace Innoplatform.Api.Controllers.RegistrationControllers
{
    public class OrganizationRegistrationController : BaseController
    {
        private readonly IOrganizationRegistrationService _organizationRegistrationService;
        public OrganizationRegistrationController(IOrganizationRegistrationService organizationRegistrationService)
        {
            _organizationRegistrationService = organizationRegistrationService;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> PostAsync([FromBody] OrganizationRegistrationForCreationDto dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._organizationRegistrationService.AddAsync(dto)
            };
            return Ok(response);
        }

        [HttpPost("SendVerificationCode")]
        public async Task<IActionResult> SendVerificationCode([FromBody] SendVerificationCode dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._organizationRegistrationService.SendVerificationCodeAsync(dto)
            };
            return Ok(response);
        }

        [HttpPost("VerifyCode")]
        public async Task<IActionResult> VerifyCode([FromBody] CodeVerification dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._organizationRegistrationService.VerifyCodeAsync(dto)
            };
            return Ok(response);
        }
    }
}
