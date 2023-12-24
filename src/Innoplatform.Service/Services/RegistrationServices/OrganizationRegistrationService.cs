using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.Interfaces.IOTPServices;

namespace Innoplatform.Service.Services.RegistrationServices
{
    public class OrganizationRegistrationService
    {
        private readonly ISmsService _smsService;
        private readonly IRepository<Organization> _organizationRepository;


        public OrganizationRegistrationService(ISmsService smsService, IRepository<Organization> organizationRepository)
        {
            _smsService = smsService;
            _organizationRepository = organizationRepository;
        }


    }
}
