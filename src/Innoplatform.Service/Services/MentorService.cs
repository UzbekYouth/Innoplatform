using Innoplatform.Service.DTOs.Mentors;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class MentorService : IMentorService
    {
        public Task<MentorForResultDto> AddAsync(MentorForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MentorForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MentorForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<MentorForResultDto> ModifyAsync(long id, MentorForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
