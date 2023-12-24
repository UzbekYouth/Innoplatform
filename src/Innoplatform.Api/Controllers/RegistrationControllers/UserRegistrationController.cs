using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.Registrations;
using Innoplatform.Service.DTOs.Registrations.UserRegistrations;
using Innoplatform.Service.Interfaces.IRegistrationServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.RegistrationControllers
{
    public class UserRegistrationController : BaseController
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public UserRegistrationController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> PostAsync([FromBody] UserRegistrationForCreationDto dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._userRegistrationService.AddAsync(dto)
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
                Data = await this._userRegistrationService.SendVerificationCodeAsync(dto)
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
                Data = await this._userRegistrationService.VerifyCodeAsync(dto)
            };
            return Ok(response);
        }
    }
}
