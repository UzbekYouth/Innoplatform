using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class MessagingService : IMessagingService
    {
        public Task<MessagingForResultDto> AddAsync(MessagingForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MessagingForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MessagingForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<MessagingForResultDto> ModifyAsync(long id, MessagingForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
