using Innoplatform.Service.DTOs.Registrations;
using Innoplatform.Service.DTOs.Registrations.UserRegistrations;

namespace Innoplatform.Service.Interfaces.IRegistrationServices
{
    public interface IUserRegistrationService
    {
        public Task<UserRegistrationForResultDto> AddAsync(UserRegistrationForCreationDto dto);
        public Task<string> SendVerificationCodeAsync(SendVerificationCode dto);
        public Task<bool> VerifyCodeAsync(CodeVerification dto);
    }
}
