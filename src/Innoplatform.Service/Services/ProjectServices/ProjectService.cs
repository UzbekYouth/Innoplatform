using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IProjectServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.ProjectServices;

public class ProjectService : IProjectService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Project> _projectRepository;

    public ProjectService(
        IMapper mapper,
        IRepository<User> userRepository,
        IRepository<Project> projectRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
    }
    public async Task<ProjectForResultDto> AddAsync(ProjectForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

        var project = await _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.UserId == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (project is not null)
            throw new InnoplatformException(409, "User already has a project");

        var mappedProject = _mapper.Map<Project>(dto);
        var createdProject = await _projectRepository.CreateAsync(mappedProject);

        return _mapper.Map<ProjectForResultDto>(createdProject);
    }

    public async Task<IEnumerable<ProjectForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var projects = await _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false)
            .Include(p => p.User)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProjectForResultDto>>(projects);
    }

    public async Task<ProjectForResultDto> GetByIdAsync(long id)
    {
        var project = await _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .Include(p => p.User)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (project is null)
            throw new InnoplatformException(404, "Project not found");

        return _mapper.Map<ProjectForResultDto>(project);
    }

    public async Task<ProjectForResultDto> ModifyAsync(long id, ProjectForUpdateDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");
        var project = await _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (project is null)
            throw new InnoplatformException(404, "Project not found");

        var mappedProject = _mapper.Map(dto, project);
        mappedProject.UpdatedAt = DateTime.UtcNow;

        var updatedProject = await _projectRepository.UpdateAsync(mappedProject);

        return _mapper.Map<ProjectForResultDto>(updatedProject);
    }

    public Task<bool> RemoveAsync(long id)
    {
        var project = _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .AsNoTracking()
            .FirstOrDefault();

        if (project is null)
            throw new InnoplatformException(404, "Project not found");

        return _projectRepository.DeleteAsync(id);
    }
}
