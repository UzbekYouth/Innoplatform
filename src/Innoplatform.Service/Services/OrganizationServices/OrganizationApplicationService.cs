using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.OrganizationApplications;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.OrganizationServices;

public class OrganizationApplicationService : IOrganizationApplicationService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<Organization> _organizationRepository;
    private readonly IRepository<OrganizationApplication> _organizationApplicationRepository;


    public OrganizationApplicationService(
               IMapper mapper,
               IRepository<User> userRepository,
               IRepository<Project> projectRepository,
               IRepository<Organization> organizationRepository,
               IRepository<OrganizationApplication> organizationApplicationRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _organizationRepository = organizationRepository;
        _organizationApplicationRepository = organizationApplicationRepository;
    }

    public async Task<OrganizationApplicationForResultDto> AddAsync(OrganizationApplicationForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

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

        var organizationApplication = await _organizationApplicationRepository.SelectAll()
            .Where(oa => oa.IsDeleted == false && oa.UserId == dto.UserId && oa.ProjectId == dto.ProjectId && oa.OrganizationId == dto.OrganizationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationApplication is not null)
            throw new InnoplatformException(409, "Organization application already exists");

        var mappedOrganizationApplication = _mapper.Map<OrganizationApplication>(dto);

        var createdOrganizationApplication = await _organizationApplicationRepository.CreateAsync(mappedOrganizationApplication);

        return _mapper.Map<OrganizationApplicationForResultDto>(createdOrganizationApplication);
    }

    public async Task<IEnumerable<OrganizationApplicationForResultDto>> GetAllAsync()
    {
        var organizationApplications = await _organizationApplicationRepository.SelectAll()
            .Where(oa => oa.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrganizationApplicationForResultDto>>(organizationApplications);
    }

    public async Task<OrganizationApplicationForResultDto> GetByIdAsync(long id)
    {
        var organizationApplication = await _organizationApplicationRepository.SelectAll()
            .Where(oa => oa.IsDeleted == false && oa.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationApplication is not null)
            throw new InnoplatformException(404, "Organization application not found");

        return _mapper.Map<OrganizationApplicationForResultDto>(organizationApplication);
    }

    public async Task<OrganizationApplicationForResultDto> ModifyAsync(long id, OrganizationApplicationForUpdateDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

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

        var organizationApplication = await _organizationApplicationRepository.SelectAll()
            .Where(oa => oa.IsDeleted == false && oa.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationApplication is null)
            throw new InnoplatformException(404, "Organization application not found");

        var mappedOrganizationApplication = _mapper.Map(dto,organizationApplication);

        mappedOrganizationApplication.UpdatedAt = DateTime.UtcNow;

        var modifiedOrganizationApplication = await _organizationApplicationRepository.UpdateAsync(mappedOrganizationApplication);

        return _mapper.Map<OrganizationApplicationForResultDto>(modifiedOrganizationApplication);
    }

    public Task<bool> RemoveAsync(long id)
    {
        var organizationApplication = _organizationApplicationRepository.SelectAll()
            .Where(oa => oa.IsDeleted == false && oa.Id == id)
            .FirstOrDefault();

        if (organizationApplication is null)
            throw new InnoplatformException(404, "Organization application not found");

        return _organizationApplicationRepository.DeleteAsync(id);
    }
}
