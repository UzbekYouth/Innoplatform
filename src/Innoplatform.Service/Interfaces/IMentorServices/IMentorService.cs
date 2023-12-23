using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.DTOs.Mentors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Interfaces.IMentorServices
{
    public interface IMentorService
    {
        Task<bool> RemoveAsync(long id);
        Task<MentorForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<MentorForResultDto>> GetAllAsync();
        Task<MentorForResultDto> AddAsync(MentorForCreationDto dto);
        Task<MentorForResultDto> ModifyAsync(long id, MentorForCreationDto dto);
    }
}
