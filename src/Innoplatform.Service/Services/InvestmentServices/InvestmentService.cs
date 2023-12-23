using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IInvestmentServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.InvestmentServices;

public class InvestmentService : IInvestmentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Investment> _repository;

    public InvestmentService(IMapper mapper, IRepository<Investment> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<InvestmentForResultDto> AddAsync(InvestmentForCreationDto dto)
    {
        var existInvestmentArea = await _repository.SelectAll()
            .Where(ei => ei.InvestmentAreaId == dto.InvestmentAreaId && ei.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (existInvestmentArea == null)
            throw new InnoplatformException(404, "InvestmentArea is not found in this ID");

        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.UserId == dto.UserId &&
                        e.InvestmentAreaId == dto.InvestmentAreaId &&
                        e.Title.ToLower() == dto.Title.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "investment is already exist");

        var mappedEntity = _mapper.Map<Investment>(dto);
        return _mapper.Map<InvestmentForResultDto>(await _repository
            .CreateAsync(mappedEntity));
    }

    public async Task<IEnumerable<InvestmentForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var entities = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Include(e => e.InvestmentArea)
            .Include(e => e.User)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<InvestmentForResultDto>>(entities);
    }

    public async Task<InvestmentForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .Include(e => e.InvestmentArea)
            .Include(e => e.User)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(404, "investment is not found");

        var mappedEntity = _mapper.Map<InvestmentForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<InvestmentForResultDto> ModifyAsync(long id, InvestmentForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(404, "investment is not found");

        var mappedEntity = _mapper.Map(dto, entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mappedEntity);
        return _mapper.Map<InvestmentForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "investment is not found");

        return await _repository.DeleteAsync(id);
    }
}
