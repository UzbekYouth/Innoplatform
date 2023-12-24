using Innoplatform.Api.Models;
using Innoplatform.Service.DTOs.OTP.Sms;
using Innoplatform.Service.Interfaces.IOTPServices;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Innoplatform.Api.Controllers.OTPContollers
{
    public class SmsController : BaseController
    {
        private readonly ISmsService _smsService;

        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Message message)
        {
            var response = new Response
            {
                Message = "Success",
                StatusCode = 200,
                Data = await this._smsService.SendAsync(message),
            };
            return Ok(response);
        }
    }
}
