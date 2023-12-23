using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IInvestmentServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.InvestmentServices;

public class InvestmentService : IInvestmentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Investment> _repository;
    private readonly IRepository<InvestmentArea> _investmentAreaRepository;


    public InvestmentService(
        IMapper mapper, 
        IRepository<User> userRepository,
        IRepository<InvestmentArea> investmentAreaRepository,
        IRepository<Investment> repository)
    {
        _mapper = mapper;
        _repository = repository;
        _userRepository = userRepository;
        _investmentAreaRepository = investmentAreaRepository;
    }
    public async Task<InvestmentForResultDto> AddAsync(InvestmentForCreationDto dto)
    {

        var existInvestmentArea = await _investmentAreaRepository.SelectAll()
            .Where(ei => ei.Id == dto.InvestmentAreaId && ei.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (existInvestmentArea == null)
            throw new InnoplatformException(404, "InvestmentArea is not found");

        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
           throw new InnoplatformException(404, "User not found");

        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.UserId == dto.UserId &&
                        e.InvestmentAreaId == dto.InvestmentAreaId &&
                        e.Title.ToLower() == dto.Title.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "investment is already exist");

        if ((dto.MaxInvestmentAmount <= dto.MinInvestmentAmount) || dto.MaxInvestmentAmount < 0 || dto.MinInvestmentAmount < 0)
            throw new InnoplatformException(400, "MaxInvestmentAmount must be greater than MinInvestmentAmount, and both must be greater than zero");

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
            .Where(e => e.IsDeleted == false && e.Id == id)
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

        var existInvestmentArea = await _investmentAreaRepository.SelectAll()
              .Where(ei => ei.Id == dto.InvestmentAreaId && ei.IsDeleted == false)
              .AsNoTracking()
              .FirstOrDefaultAsync();
        if (existInvestmentArea == null)
            throw new InnoplatformException(404, "InvestmentArea is not found");

        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

        if ((dto.MaxInvestmentAmount <= dto.MinInvestmentAmount) || dto.MaxInvestmentAmount < 0 || dto.MinInvestmentAmount < 0)
            throw new InnoplatformException(400, "MaxInvestmentAmount must be greater than MinInvestmentAmount, and both must be greater than zero");


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
