using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Service.DTOs.AboutUsAssets;
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

    public Task<AchievementForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<AchievementForResultDto> ModifyAsync(long id, AchievementForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
