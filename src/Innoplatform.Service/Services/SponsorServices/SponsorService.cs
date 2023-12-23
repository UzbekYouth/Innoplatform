using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Sponsors;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.ISponsorServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.SponsorServices;

public class SponsorService : ISponsorService
{
    private readonly IMapper _mapper;
    private readonly IFileUploadService _fileUploadService;
    private readonly IRepository<Sponsor> _sponsorRepository;

    public SponsorService(
        IMapper mapper, 
        IFileUploadService fileUploadService,
        IRepository<Sponsor> sponsorRepository)
    {
        _mapper = mapper;
        _fileUploadService = fileUploadService;
        _sponsorRepository = sponsorRepository;
    }
    public async Task<SponsorForResultDto> AddAsync(SponsorForCreationDto dto)
    {
        var sponsor = await _sponsorRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Title == dto.Title)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (sponsor is not null)
            throw new InnoplatformException(409, "Sponsor is already exist");

        var asset = new AssetForCreationDto
        {
            FolderPath = "Sponsors",
            FormFile = dto.Image
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mapped = _mapper.Map<Sponsor>(dto);
        mapped.Image = assetPath?.AssetPath;

        var result = await _sponsorRepository.CreateAsync(mapped);

        return _mapper.Map<SponsorForResultDto>(result);
    }

    public async Task<IEnumerable<SponsorForResultDto>> GetAllAsync()
    {
        var sponsors = await _sponsorRepository.SelectAll()
            .Where(r => r.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<SponsorForResultDto>>(sponsors);
    }

    public async Task<SponsorForResultDto> GetByIdAsync(long id)
    {
        var sponsor = await _sponsorRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (sponsor is null)
            throw new InnoplatformException(404, "Sponsor is not found");

        return _mapper.Map<SponsorForResultDto>(sponsor);
    }

    public async Task<SponsorForResultDto> ModifyAsync(long id, SponsorForUpdateDto dto)
    {
        var sponsor = await _sponsorRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (sponsor is null)
            throw new InnoplatformException(404, "Sponsor is not found");

        var mapped = _mapper.Map(dto, sponsor);
        mapped.UpdatedAt = DateTime.UtcNow;

        if (dto != null && dto.Image != null)
        {
            if (sponsor != null)
            {
                await _fileUploadService.DeleteFileAsync(sponsor.Image);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Sponsors",
                FormFile = dto.Image
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mapped.Image = assetPath?.AssetPath;

        }
        else
        {
            mapped.Image = mapped.Image;
        }

        var result = await _sponsorRepository.UpdateAsync(mapped);

        return _mapper.Map<SponsorForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var sponsor = await _sponsorRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .FirstOrDefaultAsync();

        if (sponsor is null)
             throw new InnoplatformException(404, "Sponsor is not found");

        if(sponsor.Image != null)
        {
            await _fileUploadService.DeleteFileAsync(sponsor.Image);
        }
        return await _sponsorRepository.DeleteAsync(id);
    }
}
