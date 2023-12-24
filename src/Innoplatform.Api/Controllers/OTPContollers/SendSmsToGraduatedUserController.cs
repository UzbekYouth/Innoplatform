using Innoplatform.Service.Interfaces.IOTPServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.OTPContollers
{
    public class SendSmsToGraduatedUserController : BaseController
    {
        private readonly ISendSmsToGraduatedUserService _sendSmsToGraduatedUserService;

        public SendSmsToGraduatedUserController(ISendSmsToGraduatedUserService sendSmsToGraduatedUserService)
        {
            _sendSmsToGraduatedUserService = sendSmsToGraduatedUserService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            var result = await this._sendSmsToGraduatedUserService.SendSmsToAllUsersAsync();
            return Ok(result);
        }

    }
}
