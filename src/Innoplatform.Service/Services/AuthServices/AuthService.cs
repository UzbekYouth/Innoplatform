using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.Login;
using Innoplatform.Service.Interfaces.IAuthServices;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;

namespace Innoplatform.Service.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Organization> _organizationRepository;

        public AuthService(IConfiguration configuration, IRepository<User> userRepository, IRepository<Organization> organizationRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
        }

        public Task<LoginForResultDto> AuthenticateAsync(LoginForCreationDto dto)
        {
            throw new NotImplementedException();
        }



       
    }
}
