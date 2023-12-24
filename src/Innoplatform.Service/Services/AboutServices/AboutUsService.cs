using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IAboutServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.AboutServices;

public class AboutUsService : IAboutUsService
{
    private readonly IMapper _mapper;
    private readonly IRepository<AboutUs> _repository;

    public AboutUsService(IRepository<AboutUs> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AboutUsForResultDto> AddAsync(AboutUsForCreationDto dto)
    {
        var aboutUs = await _repository.SelectAll()
            .Where(au => au.Title == dto.Title && au.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (aboutUs is not null)
            throw new InnoplatformException(404, "aboutUs is already exist");

        var mappedAboutUs = _mapper.Map<AboutUs>(dto);
        var result = await _repository.CreateAsync(mappedAboutUs);
        return _mapper.Map<AboutUsForResultDto>(result);
    }

    public async Task<IEnumerable<AboutUsForResultDto>> GetAllAsync()
    {
        var aboutUsList = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Include(e => e.AboutUsAssets)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AboutUsForResultDto>>(aboutUsList);
    }

    public async Task<AboutUsForResultDto> GetByIdAsync(long id)
    {
        var aboutUs = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .Include(e => e.AboutUsAssets)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (aboutUs is null)
            throw new InnoplatformException(409, "aboutUs is not found in this Id");

        var mappedAboutUs = _mapper.Map<AboutUsForResultDto>(aboutUs);
        return mappedAboutUs;
    }

    public async Task<AboutUsForResultDto> ModifyAsync(long id, AboutUsForUpdateDto dto)
    {
        var aboutUs = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (aboutUs is null)
            throw new InnoplatformException(409, "aboutUs is not found in this Id");

        var mapped = _mapper.Map(dto, aboutUs);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<AboutUsForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var aboutUs = await this._repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .Include(e => e.AboutUsAssets)
            .FirstOrDefaultAsync();

        if (aboutUs is null)
            throw new InnoplatformException(409, "aboutUs is not found in this Id");

        foreach (var relatedEntity in aboutUs.AboutUsAssets)
        {
            if (relatedEntity.Image != null)
            {
                relatedEntity.IsDeleted = true;
            }
        }

        return await _repository.DeleteAsync(id);
    }
}
