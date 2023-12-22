using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services;

public class AboutUsAssetService : IAboutUsAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<AboutUsAsset> _repository;

    public AboutUsAssetService(IMapper mapper, IRepository<AboutUsAsset> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<AboutUsAssetForResultDto> AddAsync(AboutUsAssetForCreationDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == dto.AbouteUsId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "aboutUsAsset is already exist");

        var mappedEntity = _mapper.Map<AboutUsAsset>(dto);
        return _mapper.Map<AboutUsAssetForResultDto>(await _repository
            .CreateAsync(mappedEntity));
    }

    public async Task<IEnumerable<AboutUsAssetForResultDto>> GetAllAsync()
    {
        var entities = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AboutUsAssetForResultDto>>(entities);
    }

    public async Task<AboutUsAssetForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(404, "aboutUsAsset is not found");

        var mappedEntity = _mapper.Map<AboutUsAssetForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<AboutUsAssetForResultDto> ModifyAsync(long id, AboutUsAssetForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "aboutUsAsset is not found");

        var mappedEntity = _mapper.Map(dto,entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mappedEntity);
        return _mapper.Map<AboutUsAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "aboutUsAsset is not found");

        return await _repository.DeleteAsync(id);
    }
}
