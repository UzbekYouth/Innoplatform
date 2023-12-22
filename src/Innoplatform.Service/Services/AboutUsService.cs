using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services;

public class AboutUsService : IAboutUsService
{
    private readonly IMapper _mapper;
    private readonly IRepository<AboutUs> _repository;

    public AboutUsService(IRepository<AboutUs> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AboutUsResultDto> AddAsync(AboutUsForCreationDto dto)
    {
        var aboutUs = await _repository.SelectAll()
            .Where(au => au.Title == dto.Title)
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (aboutUs is not null)
            throw new InnoplatformException(404, "aboutUs is already exist");

        var mappedAboutUs = _mapper.Map<AboutUs>(dto);
        return _mapper.Map<AboutUsResultDto>(await _repository.CreateAsync(mappedAboutUs));
    }

    public async Task<IEnumerable<AboutUsResultDto>> GetAllAsync()
    {
        var aboutUsList = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AboutUsResultDto>>(aboutUsList);
    }

    public async Task<AboutUsResultDto> GetByIdAsync(long id)
    {
        var aboutUs = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(au => au.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (aboutUs is null)
            throw new InnoplatformException(409, "aboutUs is not found in this Id");

        var mappedAboutUs = _mapper.Map<AboutUsResultDto>(aboutUs);
        return mappedAboutUs;
    }

    public async Task<AboutUsResultDto> ModifyAsync(long id, AboutUsForUpdateDto dto)
    {
        var aboutUs = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(au => au.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (aboutUs is null)
            throw new InnoplatformException(409, "aboutUs is not found in this Id");

        var mapped = _mapper.Map(dto, aboutUs);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<AboutUsResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var aboutUs = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(au => au.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (aboutUs is null)
            throw new InnoplatformException(409, "aboutUs is not found in this Id");

        return await _repository.DeleteAsync(id);
    }
}
