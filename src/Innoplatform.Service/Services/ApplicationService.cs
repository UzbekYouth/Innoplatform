using Innoplatform.Service.DTOs.Applications;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class ApplicationService : IApplicationService
    {
        public Task<ApplicationForResultDto> AddAsync(ApplicationForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
