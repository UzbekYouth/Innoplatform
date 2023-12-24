using Innoplatform.Service.DTOs.OTP.Sms;

namespace Innoplatform.Service.Interfaces.IOTPServices
{
    public interface ISmsService
    {
        public Task<bool> SendAsync(Message message);
    }
}
