using Innoplatform.Service.DTOs.Login;
using Innoplatform.Service.Interfaces.IAuthServices;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatform.Api.Controllers.AuthControllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Authenticate")]
        public async Task<IActionResult> PostAsync(LoginForCreationDto dto)
        {
            var token = await this._authService.AuthenticateAsync(dto);
            return Ok(token);
        }
    }
}
