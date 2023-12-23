using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.ProjectInvestments;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IProjectServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.ProjectServices;

public class ProjectInvestmentService : IProjectInvestmentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<Investment> _investmentRepository;
    private readonly IRepository<Application> _applicationRepository;
    private readonly IRepository<InvestmentArea> _investmentAreaRepository;
    private readonly IRepository<ProjectInvestment> _projectInvestmentRepository;

    public ProjectInvestmentService(
        IMapper mapper,
        IRepository<User> userRepository,
        IRepository<Project> projectRepository,
        IRepository<Investment> investmentRepository,
        IRepository<Application> applicationRepository,
        IRepository<InvestmentArea> investmentAreaRepository,
        IRepository<ProjectInvestment> projectInvestmentRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _investmentRepository = investmentRepository;
        _applicationRepository = applicationRepository;
        _investmentAreaRepository = investmentAreaRepository;
        _projectInvestmentRepository = projectInvestmentRepository;
    }
    public async Task<ProjectInvestmentForResultDto> AddAsync(ProjectInvestmentForCreationDto dto)
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

        var investment = await _investmentRepository.SelectAll()
            .Where(i => i.IsDeleted == false && i.Id == dto.InvestmentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investment is null)
            throw new InnoplatformException(404, "Investment not found");

        var application = await _applicationRepository.SelectAll()
            .Where(a => a.IsDeleted == false && a.Id == dto.ApplicationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (application is null)
            throw new InnoplatformException(404, "Application not found");

        var investmentArea = await _investmentAreaRepository.SelectAll()
            .Where(i => i.IsDeleted == false && i.Id == dto.IvestmentAreaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investmentArea is null)
            throw new InnoplatformException(404, "Investment area not found");

        var projectInvestment = await _projectInvestmentRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.ProjectId == dto.ProjectId && p.UserId == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (projectInvestment is not null)
            throw new InnoplatformException(409, "Project already has an investment");

        var mappedProjectInvestment = _mapper.Map<ProjectInvestment>(dto);

        var createdProjectInvestment = await _projectInvestmentRepository.CreateAsync(mappedProjectInvestment);

        return _mapper.Map<ProjectInvestmentForResultDto>(createdProjectInvestment);
    }

    public async Task<IEnumerable<ProjectInvestmentForResultDto>> GetAllAsync()
    {
        var projectInvestments = await _projectInvestmentRepository.SelectAll()
            .Where(p => p.IsDeleted == false)
            .Include(p => p.Project)
            .Include(p => p.User)
            .Include(p => p.Investment)
            .Include(p => p.Application)
            .Include(p => p.InvestmentArea)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProjectInvestmentForResultDto>>(projectInvestments);
    }

    public async Task<ProjectInvestmentForResultDto> GetByIdAsync(long id)
    {
        var projectInvestment = await _projectInvestmentRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .Include(p => p.Project)
            .Include(p => p.User)
            .Include(p => p.Investment)
            .Include(p => p.Application)
            .Include(p => p.InvestmentArea)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (projectInvestment is null)
            throw new InnoplatformException(404, "Project investment not found");

        return _mapper.Map<ProjectInvestmentForResultDto>(projectInvestment);
    }

    public async Task<ProjectInvestmentForResultDto> ModifyAsync(long id, ProjectInvestmentForUpdateDto dto)
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

        var investment = await _investmentRepository.SelectAll()
            .Where(i => i.IsDeleted == false && i.Id == dto.InvestmentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investment is null)
            throw new InnoplatformException(404, "Investment not found");

        var application = await _applicationRepository.SelectAll()
            .Where(a => a.IsDeleted == false && a.Id == dto.ApplicationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (application is null)
            throw new InnoplatformException(404, "Application not found");

        var investmentArea = await _investmentAreaRepository.SelectAll()
            .Where(i => i.IsDeleted == false && i.Id == dto.IvestmentAreaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investmentArea is null)
            throw new InnoplatformException(404, "Investment area not found");

        var projectInvestment = await _projectInvestmentRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (projectInvestment is null)
            throw new InnoplatformException(404, "Project investment not found");

        var mappedProjectInvestment = _mapper.Map(dto, projectInvestment);
        mappedProjectInvestment.UpdatedAt = DateTime.UtcNow;

        var updatedProjectInvestment = await _projectInvestmentRepository.UpdateAsync(mappedProjectInvestment);

        return _mapper.Map<ProjectInvestmentForResultDto>(updatedProjectInvestment);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var projectInvestment = await _projectInvestmentRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (projectInvestment is null)
            throw new InnoplatformException(404, "Project investment not found");

        return await _projectInvestmentRepository.DeleteAsync(id);
    }
}
