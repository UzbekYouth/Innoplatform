using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.Applications;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services;

public class ApplicationService : IApplicationService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Application> _repository;

    public ApplicationService(IMapper mapper, IRepository<Application> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ApplicationForResultDto> AddAsync(ApplicationForCreationDto dto)
    {
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

    public async Task<IEnumerable<ApplicationForResultDto>> GetAllAsync()
    {
        var entities = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();
           
        return _mapper.Map<IEnumerable<ApplicationForResultDto>>(entities);
    }

    public async Task<ApplicationForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is  null)
            throw new InnoplatformException(400, "application is not found");

        var mappedEntity = _mapper.Map<ApplicationForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
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
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is null)
            throw new InnoplatformException(400, "application is not found");

        return await _repository.DeleteAsync(id);
    }
}
