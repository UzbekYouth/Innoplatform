using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.OrganizationInvestment;
using Innoplatform.Service.DTOs.OrganizationProjectInvestments;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.OrganizationServices
{
    public class OrganizationProjectInvestmentService : IOrganizationProjectInvestmentService
    {
        private readonly IRepository<OrganizationProjectInvestment> _organizationProjectInvestmentRepository;
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Application> _applicationRepository;
        private readonly IRepository<InvestmentArea> _investmentAreaRepository;
        private readonly IMapper _mapper;

        public OrganizationProjectInvestmentService(IMapper mapper, IRepository<InvestmentArea> investmentAreaRepository, IRepository<Application> applicationRepository, IRepository<User> userRepository, IRepository<Organization> organizationRepository, IRepository<OrganizationProjectInvestment> organizationProjectInvestmentRepository)
        {
            _mapper = mapper;
            _investmentAreaRepository = investmentAreaRepository;
            _applicationRepository = applicationRepository;
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _organizationProjectInvestmentRepository = organizationProjectInvestmentRepository;
        }

        public async Task<OrganizationProjectInvestmentForResultDto> AddAsync(OrganizationProjectInvestmentForCreationDto dto)
        {
            var check = await _organizationProjectInvestmentRepository.SelectAll()
                .Where(o => o.IsDeleted == false && o.ApplicationId == dto.ApplicationId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (check is not null)
                throw new InnoplatformException(409, "Organization project investment already exists");
<<<<<<< HEAD

=======
            
>>>>>>> a69aa455dc3b48c068099841f72905c9dcb4b4ee
            var application = await _applicationRepository.SelectAll()
                .Where(a => a.IsDeleted == false && a.Id == dto.ApplicationId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (application is null)
                throw new InnoplatformException(404, "Application not found");
<<<<<<< HEAD

            var organization = await _organizationRepository.SelectAll()
                .Where(o => o.IsDeleted == false && o.Id == dto.OrganizationId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (organization is null)
                throw new InnoplatformException(404, "Organization not found");

            var user = await _userRepository.SelectAll()
                .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

                if (user is null)
                throw new InnoplatformException(404, "User not found");

            var investmentArea = await _investmentAreaRepository.SelectAll()
                .Where(i => i.IsDeleted == false && i.Id == dto.InvestmentAreaId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (investmentArea is null)
                throw new InnoplatformException(404, "Investment area not found");

=======
            
            var organization = await _organizationRepository.SelectAll().Where(o => o.IsDeleted == false && o.Id == dto.OrganizationId).AsNoTracking().FirstOrDefaultAsync();
            if (organization is null)
                throw new InnoplatformException(404, "Organization not found");
            
            var user = await _userRepository.SelectAll().Where(u => u.IsDeleted == false && u.Id == dto.UserId).AsNoTracking().FirstOrDefaultAsync();
            if (user is null)
                throw new InnoplatformException(404, "User not found");
            
            var investmentArea = await _investmentAreaRepository.SelectAll().Where(i => i.IsDeleted == false && i.Id == dto.InvestmentAreaId).AsNoTracking().FirstOrDefaultAsync();
            if (investmentArea is null)
                throw new InnoplatformException(404, "Investment area not found");
            
>>>>>>> a69aa455dc3b48c068099841f72905c9dcb4b4ee
            var mappedOrganizationProjectInvestment = _mapper.Map<OrganizationProjectInvestment>(dto);

            var createdOrganizationProjectInvestment = await _organizationProjectInvestmentRepository.CreateAsync(mappedOrganizationProjectInvestment);

            return _mapper.Map<OrganizationProjectInvestmentForResultDto>(createdOrganizationProjectInvestment);

        }
        public async Task<IEnumerable<OrganizationProjectInvestmentForResultDto>> GetAllAsync()
        {
            var organizationProjectInvestments = await _organizationProjectInvestmentRepository.SelectAll()
                .Where(o => o.IsDeleted == false)
                .Include(o => o.Application)
                .Include(o => o.Organization)
                .Include(o => o.User)
                .Include(o => o.Investment)
                .AsNoTracking()
                .ToListAsync();

            if (organizationProjectInvestments is null)
                throw new InnoplatformException(404, "Organization project investment not found");

            return _mapper.Map<IEnumerable<OrganizationProjectInvestmentForResultDto>>(organizationProjectInvestments);
        }

        public async Task<OrganizationProjectInvestmentForResultDto> GetByIdAsync(long id)
        {
            var organizationProjectInvestment = await _organizationProjectInvestmentRepository.SelectAll()
                .Where(o => o.IsDeleted == false && o.Id == id)
                .Include(o => o.Application)
                .Include(o => o.Organization)
                .Include(o => o.User)
                .Include(o => o.Investment)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (organizationProjectInvestment is null)
                throw new InnoplatformException(404, "Organization project investment not found");

            return _mapper.Map<OrganizationProjectInvestmentForResultDto>(organizationProjectInvestment);

        }

        public async Task<OrganizationProjectInvestmentForResultDto> ModifyAsync(long id, OrganizationProjectInvestmentForUpdateDto dto)
        {
            var organizationProjectInvestment = await _organizationProjectInvestmentRepository.SelectAll()
                .Where(o => o.IsDeleted == false && o.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (organizationProjectInvestment is null)
                throw new InnoplatformException(404, "Organization project investment not found");


            var mappedData = _mapper.Map(dto, organizationProjectInvestment);
            mappedData.UpdatedAt = DateTime.UtcNow;

            var updatedOrganizationProjectInvestment = await _organizationProjectInvestmentRepository.UpdateAsync(mappedData);

            return _mapper.Map<OrganizationProjectInvestmentForResultDto>(updatedOrganizationProjectInvestment);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var organizationProjectInvestment = await _organizationProjectInvestmentRepository.SelectAll()
                .Where(o => o.IsDeleted == false && o.Id == id)
                .FirstOrDefaultAsync();

            if (organizationProjectInvestment is null)
                throw new InnoplatformException(404, "Organization project investment not found");

             return await _organizationProjectInvestmentRepository.DeleteAsync(id);
        }
    }
}
