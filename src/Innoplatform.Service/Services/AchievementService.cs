using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services;

public class AchievementService : IAchievementService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Achievement> _repository;

    public AchievementService(IMapper mapper, IRepository<Achievement> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<AchievementForResultDto> AddAsync(AchievementForCreationDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.Title == dto.Title)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "achievement is already exist");

        var mappedEntity = _mapper.Map<Achievement>(dto);
        return _mapper.Map<AchievementForResultDto>(await _repository
            .CreateAsync(mappedEntity));
    }

    public async Task<IEnumerable<AchievementForResultDto>> GetAllAsync()
    {
        var entities = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AchievementForResultDto>>(entities);
    }

    public async Task<AchievementForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (entity is null)
            throw new InnoplatformException(404, "Achievement is not found");

        return _mapper.Map<AchievementForResultDto>(entity);
    }

    public async Task<AchievementForResultDto> ModifyAsync(long id, AchievementForUpdateDto dto)
    {
        var sponsor = await _repository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (sponsor is null)
            throw new InnoplatformException(404, "Achievement is not found");

        var mapped = _mapper.Map(dto, sponsor);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<AchievementForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var sponsor = await _repository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (sponsor is null)
            throw new InnoplatformException(404, "Achievement is not found");

        return await _repository.DeleteAsync(id);
    }
}
