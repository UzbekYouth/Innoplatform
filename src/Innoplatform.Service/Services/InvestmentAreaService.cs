using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class InvestmentAreaService : IInvestmentAreaService
    {
        public Task<InvestmentAreaForResultDto> AddAsync(InvestmentAreaForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvestmentAreaForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InvestmentAreaForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<InvestmentAreaForResultDto> ModifyAsync(long id, InvestmentAreaForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
