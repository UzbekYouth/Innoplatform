using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Service.DTOs.OrganizationInvestment;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.OrganizationServices
{
    public class OrganizationInvestmentService : IOrganizationInvestmentService
    {
        private readonly IRepository<OrganizationInvestment> _repository;

        private readonly IMapper mapper;
        private readonly IRepository<Organization> _organizationRepository;
        public OrganizationInvestmentService(IRepository<OrganizationInvestment> repository, IMapper mapper, IRepository<Organization> organizationRepository)
        {
            _repository = repository;
            this.mapper = mapper;
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationInvestmentForResultDto> AddAsync(OrganizationInvestmentForCreationDto dto)
        {

            var Check = await this._repository.SelectAll().Where(o => o.OrganizationId == dto.OrganizationId && o.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (Check != null)
            {
                throw new InnoplatformException(409, "Organization already has a project investment");
            }
            var organization = await this._organizationRepository.SelectAll().Where(o => o.Id == dto.OrganizationId && o.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (organization == null)
            {
                throw new InnoplatformException(404, "Organization not found");
            }
            var mapped = this.mapper.Map<OrganizationInvestment>(dto);
            var created = await this._repository.CreateAsync(mapped);
            return this.mapper.Map<OrganizationInvestmentForResultDto>(created);
        }

        public async Task<IEnumerable<OrganizationInvestmentForResultDto>> GetAllAsync()
        {
            var result = await this._repository.SelectAll().Where(o => o.IsDeleted == false).AsNoTracking().ToListAsync();
            return this.mapper.Map<IEnumerable<OrganizationInvestmentForResultDto>>(result);
        }

        public async Task<OrganizationInvestmentForResultDto> GetByIdAsync(long id)
        {
            var result = await this._repository.SelectAll().Where(o => o.Id == id && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            return this.mapper.Map<OrganizationInvestmentForResultDto>(result);
        }

        public async Task<OrganizationInvestmentForResultDto> ModifyAsync(long id, OrganizationInvestmentForUpdateDto dto)
        {
            var result = await this._repository.SelectAll().Where(o => o.Id == id && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (result == null)
            {
                throw new InnoplatformException(404, "Organization project investment not found");
            }

            var mapped = this.mapper.Map(dto, result);
            var updated = await this._repository.UpdateAsync(mapped);
            return this.mapper.Map<OrganizationInvestmentForResultDto>(updated);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var result = await this._repository.SelectAll().Where(o => o.Id == id && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (result == null)
            {
                throw new InnoplatformException(404, "Organization project investment not found");
            }
            return await this._repository.DeleteAsync(id);

        }
    }
}
