using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.DTOs.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Interfaces.IProjectServices
{
    public interface IApplicationService
    {
        Task<bool> RemoveAsync(long id);
        Task<ApplicationForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<ApplicationForResultDto>> GetAllAsync();
        Task<ApplicationForResultDto> AddAsync(ApplicationForCreationDto dto);
        Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto);
    }
}
