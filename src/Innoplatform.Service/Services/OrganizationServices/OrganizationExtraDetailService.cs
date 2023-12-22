using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Service.DTOs.OrganizationExtraDetails;
using Innoplatform.Service.DTOs.ProjectAssets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.OrganizationServices;

public class OrganizationExtraDetailService : IOrganizationExtraDetailService
{

    private readonly IMapper _mapper;
    private readonly IRepository<Organization> _organizationRepository;
    private readonly IRepository<OrganizationExtraDetails> _organizationExtraDetailRepository;

    public OrganizationExtraDetailService(
            IMapper mapper,
            IRepository<Organization> organizationRepository,
            IRepository<OrganizationExtraDetails> organizationExtraDetailRepository)
    {
        _mapper = mapper;
        _organizationRepository = organizationRepository;
        _organizationExtraDetailRepository = organizationExtraDetailRepository;
    }

    public async Task<OrganizationExtraDetailForResultDto> AddAsync(OrganizationExtraDetailForCreationDto dto)
    {
        var organization = await _organizationRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == dto.OrganizationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organization is null)
            throw new InnoplatformException(404, "Organization not found");

        var organizationExtraDetail = await _organizationExtraDetailRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.OrganizationId == dto.OrganizationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationExtraDetail is not null)
            throw new InnoplatformException(409, "Organization already has an extra detail");

        var mappedOrganizationExtraDetail = _mapper.Map<OrganizationExtraDetails>(dto);

        var createdOrganizationExtraDetail = await _organizationExtraDetailRepository.CreateAsync(mappedOrganizationExtraDetail);

        return _mapper.Map<OrganizationExtraDetailForResultDto>(createdOrganizationExtraDetail);
    }

    public async Task<IEnumerable<OrganizationExtraDetailForResultDto>> GetAllAsync()
    {
        var organizationExtraDetails = await _organizationExtraDetailRepository.SelectAll()
            .Where(o => o.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrganizationExtraDetailForResultDto>>(organizationExtraDetails);
    }

    public async Task<OrganizationExtraDetailForResultDto> GetByIdAsync(long id)
    {
        var organizationExtraDetail = await _organizationExtraDetailRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationExtraDetail is null)
            throw new InnoplatformException(404, "Organization extra detail not found");

       return _mapper.Map<OrganizationExtraDetailForResultDto>(organizationExtraDetail);
    }

    public async Task<OrganizationExtraDetailForResultDto> ModifyAsync(long id, OrganizationExtraDetailForUpdateDto dto)
    {
        var organization = await _organizationRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == dto.OrganizationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organization is null)
            throw new InnoplatformException(404, "Organization not found");

        var organizationExtraDetail = await _organizationExtraDetailRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (organizationExtraDetail is null)
            throw new InnoplatformException(404, "Organization extra detail not found");

        var mappedOrganizationExtraDetail = _mapper.Map(dto, organizationExtraDetail);
        mappedOrganizationExtraDetail.UpdatedAt = DateTime.UtcNow;

        var updatedOrganizationExtraDetail = await _organizationExtraDetailRepository.UpdateAsync(mappedOrganizationExtraDetail);

        return _mapper.Map<OrganizationExtraDetailForResultDto>(updatedOrganizationExtraDetail);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var organizationExtraDetail = await _organizationExtraDetailRepository.SelectAll()
            .Where(o => o.IsDeleted == false && o.Id == id)
            .FirstOrDefaultAsync();

        if (organizationExtraDetail is null)
            throw new InnoplatformException(404, "Organization extra detail not found");

        return await _organizationExtraDetailRepository.DeleteAsync(id);
    }
}
