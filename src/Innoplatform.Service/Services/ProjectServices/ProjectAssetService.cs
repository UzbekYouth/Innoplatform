using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.ProjectAssets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.ProjectServices;

public class ProjectAssetService : IProjectAssetService
{
    private readonly IMapper _mapper;
    private readonly IFileUploadService _fileUploadService;
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<ProjectAsset> _projectAssetRepository;
    public ProjectAssetService(
            IMapper mapper,
            IFileUploadService fileUploadService,
            IRepository<Project> projectRepository,
            IRepository<ProjectAsset> projectAssetRepository)
    {
        _mapper = mapper;
        _fileUploadService = fileUploadService;
        _projectRepository = projectRepository;
        _projectAssetRepository = projectAssetRepository;
    }
    public async Task<ProjectAssetForResultDto> AddAsync(OrganizationExtraDetailForCreationDto dto)
    {
        var project = await _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == dto.ProjectId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (project is null)
            throw new InnoplatformException(404, "Project not found");

        var projectAsset = await _projectAssetRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.ProjectId == dto.ProjectId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (projectAsset is not null)
            throw new InnoplatformException(409, "Project already has an asset");

        var asset = new AssetForCreationDto
        {
            FolderPath = "Projects",
            FormFile = dto.File
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);
        var mappedProjectAsset = _mapper.Map<ProjectAsset>(dto);
        mappedProjectAsset.File = assetPath?.AssetPath;

        var createdProjectAsset = await _projectAssetRepository.CreateAsync(mappedProjectAsset);

        return _mapper.Map<ProjectAssetForResultDto>(createdProjectAsset);
    }

    public async Task<IEnumerable<ProjectAssetForResultDto>> GetAllAsync()
    {
        var projectAssets = await _projectAssetRepository.SelectAll()
            .Where(p => p.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProjectAssetForResultDto>>(projectAssets);
    }

    public async Task<ProjectAssetForResultDto> GetByIdAsync(long id)
    {
        var projectAsset = await _projectAssetRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (projectAsset is null)
            throw new InnoplatformException(404, "Project asset not found");

        return _mapper.Map<ProjectAssetForResultDto>(projectAsset);
    }

    public async Task<ProjectAssetForResultDto> ModifyAsync(long id, ProjectAssetForUpdateDto dto)
    {
        var project = _projectRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == dto.ProjectId)
            .AsNoTracking()
            .FirstOrDefault();

        if (project == null)
            throw new InnoplatformException(404, "Project not found");

        var projectAsset = _projectAssetRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .AsNoTracking()
            .FirstOrDefault();

        if (projectAsset == null)
            throw new InnoplatformException(404, "Project asset not found");

        var mappedProjectAsset = _mapper.Map(dto, projectAsset);
        
        if (dto != null && dto.File != null)
        {
            if(projectAsset != null)
            {
                await _fileUploadService.DeleteFileAsync(projectAsset.File);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Projects",
                FormFile = dto.File
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mappedProjectAsset.File = assetPath?.AssetPath;

        }
        else
        {
            mappedProjectAsset.File = mappedProjectAsset.File;
        }

        mappedProjectAsset.UpdatedAt = DateTime.UtcNow;
        var updatedProjectAsset = await _projectAssetRepository.UpdateAsync(mappedProjectAsset);
        return _mapper.Map<ProjectAssetForResultDto>(updatedProjectAsset);

    }

    public async Task<bool> RemoveAsync(long id)
    {
        var projectAsset = await _projectAssetRepository.SelectAll()
            .Where(p => p.IsDeleted == false && p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (projectAsset is null)
            throw new InnoplatformException(404, "Project asset not found");
        if(projectAsset.File != null)
        {
            await _fileUploadService.DeleteFileAsync(projectAsset.File);
        }
        return await _projectAssetRepository.DeleteAsync(id);
    }
}
