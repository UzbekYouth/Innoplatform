using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Mentors;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Mentors;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IMentorServices;
using Microsoft.EntityFrameworkCore;
namespace Innoplatform.Service.Services;
public class MentorService : IMentorService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Mentor> _repository;
    private readonly IFileUploadService _fileUploadService;

    public MentorService(IMapper mapper,
        IRepository<Mentor> repository,
        IFileUploadService fileUploadService)
    {
        _mapper = mapper;
        _repository = repository;
        _fileUploadService = fileUploadService;
    }
    public async Task<MentorForResultDto> AddAsync(MentorForCreationDto dto)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.FirstName.ToLower() == dto.FirstName.ToLower() &&
                    e.LastName.ToLower() == dto.LastName.ToLower() &&
                    e.Position == dto.Position)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "mentor is already exist");

        var asset = new AssetForCreationDto
        {
            FolderPath = "Mentors",
            FormFile = dto.Image
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mappedMentor = _mapper.Map<Mentor>(dto);
        mappedMentor.Image = assetPath?.AssetPath;

        var result = await _repository.CreateAsync(mappedMentor);

        return _mapper.Map<MentorForResultDto>(result);
    }

    public async Task<IEnumerable<MentorForResultDto>> GetAllAsync()
    {
        var entities = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .ToListAsync();

        return _mapper.Map<IEnumerable<MentorForResultDto>>(entities);
    }

    public async Task<MentorForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(404, "mentor is not found");

        var mappedEntity = _mapper.Map<MentorForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<MentorForResultDto> ModifyAsync(long id, MentorForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(404, "mentor is not found");

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
                FolderPath = "Mentors",
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
        return _mapper.Map<MentorForResultDto>(result);
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
        .Where(e => e.IsDeleted == false)
        .Where(e => e.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "mentor is not found");

        return await _repository.DeleteAsync(id);
    }
}