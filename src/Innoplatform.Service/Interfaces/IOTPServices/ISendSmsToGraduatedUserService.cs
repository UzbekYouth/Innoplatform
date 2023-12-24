namespace Innoplatform.Service.Interfaces.IOTPServices
{
    public interface ISendSmsToGraduatedUserService
    {
        public Task<bool> SendSmsToAllUsersAsync();

    }
}
