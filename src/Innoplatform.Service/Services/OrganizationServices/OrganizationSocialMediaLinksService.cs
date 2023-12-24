using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatform.Service.Exceptions;
using Innoplatform.Data.IRepositories;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Innoplatform.Service.DTOs.OrganizationSocialMediaLinks;

namespace Innoplatform.Service.Services.OrganizationServices
{
    public class OrganizationSocialMediaLinksService : IOrganizationSocialMediaLinkService
    {
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<OrganizationSocialMediaLink> _repository;

        public OrganizationSocialMediaLinksService(

            IMapper mapper,
            IFileUploadService fileUploadService,
            IRepository<Organization> organizationRepository,
            IRepository<OrganizationSocialMediaLink> repository)
        {
            _mapper = mapper;
            _repository = repository;
            _fileUploadService = fileUploadService;
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationSocialMediaLinkForResultDto> AddAsync(OrganizationSocialMediaLinkForCreationDto dto)
        {
            var organization = await _organizationRepository.SelectAll()
                .Where(o => o.Id == dto.OrganizationId && o.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (organization == null)
                throw new InnoplatformException(404, "Not Found");
            
            var existingLink = await _repository.SelectAll()
                .Where(o => o.OrganizationId == dto.OrganizationId && o.Title == dto.Title && o.Url == dto.Url && o.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (existingLink != null)
            {
                throw new InnoplatformException(404, "This Social Media Link is exist");
            }
            var organizationSocialMediaLink = _mapper.Map<OrganizationSocialMediaLink>(dto);

            var assetDetails = new AssetForCreationDto
            {
                FolderPath = "OrganizationSocialMediaLinks",
                FormFile = dto.Image
            };

            var savedFile = await _fileUploadService.FileUploadAsync(assetDetails);
            organizationSocialMediaLink.Image = savedFile.AssetPath;

            var result = await _repository.CreateAsync(organizationSocialMediaLink);
            return _mapper.Map<OrganizationSocialMediaLinkForResultDto>(result);
        }

        public async Task<IEnumerable<OrganizationSocialMediaLinkForResultDto>> GetAllAsync()
        {
            var result = await _repository.SelectAll()
                .Where(o => o.IsDeleted == false)
                .Include(r => r.Organization)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<IEnumerable<OrganizationSocialMediaLinkForResultDto>>(result);
        }

        public async Task<OrganizationSocialMediaLinkForResultDto> GetByIdAsync(long id)
        {
            var result = await _repository.SelectAll()
                .Where(o => o.Id == id && o.IsDeleted == false)
                .Include(r => r.Organization)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (result == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }

            return _mapper.Map<OrganizationSocialMediaLinkForResultDto>(result);
        }

        public async Task<OrganizationSocialMediaLinkForResultDto> ModifyAsync(long id, OrganizationSocialMediaLinkForUpdateDto dto)
        {
            var existingLink = await _repository.SelectAll()
                .Where(o => o.Id == id && o.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (existingLink == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }

            var organization = await _organizationRepository.SelectAll()
                .Where(o => o.Id == dto.OrganizationId && o.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (organization == null)
                throw new InnoplatformException(404, "Not Found");

            // Update properties
            existingLink.Title = dto.Title;
            existingLink.Url = dto.Url;
            existingLink.OrganizationId = existingLink.OrganizationId;
            // Upload and save the new image
            if (dto.Image != null)
            {
                if (!string.IsNullOrEmpty(existingLink.Image))
                {
                    await _fileUploadService.DeleteFileAsync(existingLink.Image);
                }

                var assetDetails = new AssetForCreationDto
                {
                    FolderPath = "OrganizationSocialMediaLinks",
                    FormFile = dto.Image
                };

                var savedFile = await _fileUploadService.FileUploadAsync(assetDetails);
                existingLink.Image = savedFile.AssetPath;
            }

            existingLink.UpdatedAt = DateTime.UtcNow;
            var result = await _repository.UpdateAsync(existingLink);
            return _mapper.Map<OrganizationSocialMediaLinkForResultDto>(result);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var existingLink = await _repository.SelectAll().Where(o => o.Id == id).FirstOrDefaultAsync();
            if (existingLink == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }

            if (existingLink.Image != null)
            {
                await _fileUploadService.DeleteFileAsync(existingLink.Image);
            }

            return await _repository.DeleteAsync(id);
        }
    }
}
