using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class InvestmentService : IInvestmentService
    {
        public Task<InvestmentForResultDto> AddAsync(InvestmentForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvestmentForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InvestmentForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<InvestmentForResultDto> ModifyAsync(long id, InvestmentForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
