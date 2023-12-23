using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IInvestmentServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.InvestmentServices;

public class InvestmentAreaService : IInvestmentAreaService
{
    private readonly IMapper _mapper;
    private readonly IRepository<InvestmentArea> _repository;
    private readonly IFileUploadService _fileUploadService;

    public InvestmentAreaService(IMapper mapper, 
        IRepository<InvestmentArea> repository,
        IFileUploadService fileUploadService)
    {
        _mapper = mapper;
        _repository = repository;
        _fileUploadService = fileUploadService;
    }
    public async Task<InvestmentAreaForResultDto> AddAsync(InvestmentAreaForCreationDto dto)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Title == dto.Title)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "InvestmentArea is already exist");

        var asset = new AssetForCreationDto
        {
            FolderPath = "InvestmentAreas",
            FormFile = dto.Image
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mapped = _mapper.Map<InvestmentArea>(dto);
        mapped.Image = assetPath?.AssetPath;

        var mappedEntity = _mapper.Map<InvestmentArea>(dto);
        return _mapper.Map<InvestmentAreaForResultDto>(await _repository
            .CreateAsync(mappedEntity));
    }

    public async Task<IEnumerable<InvestmentAreaForResultDto>> GetAllAsync()
    {
        var entities = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .ToListAsync();

        return _mapper.Map<IEnumerable<InvestmentAreaForResultDto>>(entities);
    }

    public async Task<InvestmentAreaForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity is null)
            throw new InnoplatformException(400, "InvestmentArea is not found ");

        var mappedEntity = _mapper.Map<InvestmentAreaForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<InvestmentAreaForResultDto> ModifyAsync(long id, InvestmentAreaForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is null)
            throw new InnoplatformException(400, "InvestmentArea is not found");

        var mappedEntity = _mapper.Map(dto, entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;

        if (dto != null && dto.Image != null)
        {
            if (entity != null)
            {
                await _fileUploadService.DeleteFileAsync(entity.Image);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "InvestmentAreas",
                FormFile = dto.Image
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mappedEntity.Image = assetPath?.AssetPath;
        }
        else
        {
            mappedEntity.Image = mappedEntity.Image;
        }

        var result = await _repository.UpdateAsync(mappedEntity);
        return _mapper.Map<InvestmentAreaForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "investmentarea is not found");

        if (entity.Image != null)
            await _fileUploadService.DeleteFileAsync(entity.Image);

        return await _repository.DeleteAsync(id);
    }
}
