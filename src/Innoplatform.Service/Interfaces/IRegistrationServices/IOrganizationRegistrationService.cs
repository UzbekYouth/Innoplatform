using Innoplatform.Service.DTOs.Registrations;
using Innoplatform.Service.DTOs.Registrations.OrganizationRegistrations;

namespace Innoplatform.Service.Interfaces.IRegistrationServices
{
    public interface IOrganizationRegistrationService
    {
        public Task<OrganizationRegistrationForResultDto> AddAsync(OrganizationRegistrationForCreationDto dto);
        public Task<string> SendVerificationCodeAsync(SendVerificationCode dto);
        public Task<bool> VerifyCodeAsync(CodeVerification dto);
    }
}
