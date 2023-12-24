using Innoplatform.Service.DTOs.Login;

namespace Innoplatform.Service.Interfaces.IAuthServices
{
    public interface IAuthService
    {
        public Task<LoginForResultDto> AuthenticateAsync(LoginForCreationDto dto);

    }
}
