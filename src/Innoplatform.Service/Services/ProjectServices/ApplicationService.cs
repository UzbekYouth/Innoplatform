using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.Applications;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IProjectServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.ProjectServices;

public class ApplicationService : IApplicationService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Application> _repository;
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<Investment> _investmentRepository;
    private readonly IRepository<InvestmentArea> _investmentAreaRepository;
    
    public ApplicationService(
        IMapper mapper, 
        IRepository<User> userRepository,
        IRepository<Application> repository,
        IRepository<Project> projectRepository,
        IRepository<Investment> investmentRepository,
        IRepository<InvestmentArea> investmentAreaRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _investmentRepository = investmentRepository;
        _investmentAreaRepository = investmentAreaRepository;
    }
    public async Task<ApplicationForResultDto> AddAsync(ApplicationForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new InnoplatformException(400, "user is not found");

        var project = await _projectRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.ProjectId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (project is null)
            throw new InnoplatformException(400, "project is not found");

        var investment = await _investmentRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.InvestmentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investment is null)
            throw new InnoplatformException(400, "investment is not found");

        var investmentArea = await _investmentAreaRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.InvestmentAreaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investmentArea is null)
            throw new InnoplatformException(400, "investment area is not found");

        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.UserId == dto.UserId &&
                        e.ProjectId == dto.ProjectId &&
                        e.InvestmentAreaId == dto.InvestmentAreaId &&
                        e.InvestmentId == dto.InvestmentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "application is already exist");

        var mappedEntity = _mapper.Map<Application>(dto);
        return _mapper.Map<ApplicationForResultDto>(await _repository
            .CreateAsync(mappedEntity));
    }

    public async Task<IEnumerable<ApplicationForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var entities = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Include(e => e.InvestmentArea)
            .Include(e => e.Investment)
            .Include(e => e.Project)
            .Include(e => e.User)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApplicationForResultDto>>(entities);
    }

    public async Task<ApplicationForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .Include(e => e.InvestmentArea)
            .Include(e => e.Investment)
            .Include(e => e.Project)
            .Include(e => e.User)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is null)
            throw new InnoplatformException(400, "application is not found");

        var mappedEntity = _mapper.Map<ApplicationForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new InnoplatformException(400, "user is not found");

        var project = await _projectRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.ProjectId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (project is null)
            throw new InnoplatformException(400, "project is not found");

        var investment = await _investmentRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.InvestmentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investment is null)
            throw new InnoplatformException(400, "investment is not found");

        var investmentArea = await _investmentAreaRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == dto.InvestmentAreaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (investmentArea is null)
            throw new InnoplatformException(400, "investment area is not found");
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is null)
            throw new InnoplatformException(400, "application is not found");

        var mappedEntity = _mapper.Map(dto, entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mappedEntity);

        return _mapper.Map<ApplicationForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is null)
            throw new InnoplatformException(400, "application is not found");

        return await _repository.DeleteAsync(id);
    }
}
