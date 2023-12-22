using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Educations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Educations;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.EducationServices;

public class EducationService : IEducationService
{
    private readonly IMapper _mapper;
    private readonly IFileUploadService _fileUploadService;
    private readonly IRepository<Education> _educationRepository;
    public EducationService(
        IMapper mapper, 
        IFileUploadService fileUploadService,
        IRepository<Education> educationRepository)
    {
        _mapper = mapper;
        _fileUploadService = fileUploadService;
        _educationRepository = educationRepository;
    }
    public async Task<EducationForResultDto> AddAsync(EducationForCreationDto dto)
    {
        var education = await _educationRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.PhoneNumber == dto.PhoneNumber && e.Latitude == dto.Latitude && e.Longitude == dto.Longitude)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (education is not null)
            throw new InnoplatformException(409, "Education already exists");

        var asset = new AssetForCreationDto
        {
            FolderPath = "Educations",
            FormFile = dto.Image
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mappedEducation = _mapper.Map<Education>(dto);
        mappedEducation.Image = assetPath?.AssetPath;

        var createdEducation = await _educationRepository.CreateAsync(mappedEducation);

        return _mapper.Map<EducationForResultDto>(createdEducation);
    }

    public async Task<IEnumerable<EducationForResultDto>> GetAllAsync()
    {
        var educations = await _educationRepository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<EducationForResultDto>>(educations);
    }

    public async Task<EducationForResultDto> GetByIdAsync(long id)
    {
        var education = await _educationRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (education is null)
            throw new InnoplatformException(404, "Education not found");

        return _mapper.Map<EducationForResultDto>(education);

    }

    public async Task<EducationForResultDto> ModifyAsync(long id, EducationForUpdateDto dto)
    {
        var education = await _educationRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (education is null)
            throw new InnoplatformException(404, "Education not found");

        var mappedEducation = _mapper.Map(dto, education);
        mappedEducation.UpdatedAt = DateTime.UtcNow;

        if (dto != null && dto.Image != null)
        {
            if (education != null)
            {
                await _fileUploadService.DeleteFileAsync(education.Image);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Educations",
                FormFile = dto.Image
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mappedEducation.Image = assetPath?.AssetPath;

        }
        else
        {
            mappedEducation.Image = mappedEducation.Image;
        }


        var modifiedEducation = await _educationRepository.UpdateAsync(mappedEducation);

        return _mapper.Map<EducationForResultDto>(modifiedEducation);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var education = await _educationRepository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (education is null)
            throw new InnoplatformException(404, "Education not found");

        if(education.Image != null)
            await _fileUploadService.DeleteFileAsync(education.Image);

        return await _educationRepository.DeleteAsync(id);
    }
}
