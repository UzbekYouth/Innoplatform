using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Service.DTOs.OrganizationInvestmentInvitations;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.OrganizationServices;

public class OrganizationInvestmentInvitationService : IOrganizationInvestmentInvitationService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<Organization> _organizationRepository;
    private readonly IRepository<OrganizationInvestmentInvitation> _organizationInvestmentInvitationRepository;


    public OrganizationInvestmentInvitationService(
               IMapper mapper,
               IRepository<Project> projectRepository,
               IRepository<Organization> organizationRepository,
               IRepository<OrganizationInvestmentInvitation> organizationInvestmentInvitationRepository)
    {
        _mapper = mapper;
        _projectRepository = projectRepository;
        _organizationRepository = organizationRepository;
        _organizationInvestmentInvitationRepository = organizationInvestmentInvitationRepository;
    }

    public async Task<OrganizationInvestmentInvitationForResultDto> AddAsync(OrganizationInvestmentInvitationForCreationDto dto)
    {
        var project = await _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == dto.ProjectId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (project is null)
            throw new InnoplatformException(404, "Project not found");

        var organization = await _organizationRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == dto.OrganizationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organization is null)
            throw new InnoplatformException(404, "Organization not found");

        var organizationInvestmentInvitation = await _organizationInvestmentInvitationRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.ProjectId == dto.ProjectId && o.OrganizationId == dto.OrganizationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationInvestmentInvitation is not null)
            throw new InnoplatformException(409, "Organization already has an invitation");

        var mappedOrganizationInvestmentInvitation = _mapper.Map<OrganizationInvestmentInvitation>(dto);

        var createdOrganizationInvestmentInvitation = await _organizationInvestmentInvitationRepository.CreateAsync(mappedOrganizationInvestmentInvitation);

        return _mapper.Map<OrganizationInvestmentInvitationForResultDto>(createdOrganizationInvestmentInvitation);
    }

    public async Task<IEnumerable<OrganizationInvestmentInvitationForResultDto>> GetAllAsync()
    {
        var organizationInvestmentInvitations = await _organizationInvestmentInvitationRepository.SelectAll()
            .Where(o => o.IsDeleted == false)
            .Include(o => o.Project)
            .Include(o => o.Organization)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrganizationInvestmentInvitationForResultDto>>(organizationInvestmentInvitations);
    }

    public async Task<OrganizationInvestmentInvitationForResultDto> GetByIdAsync(long id)
    {
        var organizationInvestmentInvitation = await _organizationInvestmentInvitationRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == id)
            .Include(o => o.Project)
            .Include(o => o.Organization)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationInvestmentInvitation is null)
            throw new InnoplatformException(404, "Organization investment invitation not found");

        return _mapper.Map<OrganizationInvestmentInvitationForResultDto>(organizationInvestmentInvitation);
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var organizationInvestmentInvitation = await _organizationInvestmentInvitationRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == id)
            .FirstOrDefaultAsync();

        if (organizationInvestmentInvitation is null)
            throw new InnoplatformException(404, "Organization investment invitation not found");

        return await _organizationInvestmentInvitationRepository.DeleteAsync(id);

    }
}
