using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Messagings;
using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.MessagingServices;

public class MessagingService : IMessagingService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Messaging> _repository;

    public MessagingService(IMapper mapper, IRepository<Messaging> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<MessagingForResultDto> AddAsync(MessagingForCreationDto dto)
    {
        var mapperEntity = _mapper.Map<Messaging>(dto);
        var result = await _repository.CreateAsync(mapperEntity);

        return _mapper.Map<MessagingForResultDto>(result);
    }

    public async Task<IEnumerable<MessagingForResultDto>> GetAllAsync()
    {
        var entities = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .ToListAsync();
        return _mapper.Map<IEnumerable<MessagingForResultDto>>(entities);
    }

    public async Task<MessagingForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        var mappedEntity = _mapper.Map<MessagingForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<MessagingForResultDto> ModifyAsync(long id, MessagingForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        var mappedEntity = _mapper.Map(dto, entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mappedEntity);
        return _mapper.Map<MessagingForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (entity == null)
            throw new InnoplatformException(400, "Messaging is empty");

        return await _repository.DeleteAsync(id);
    }
}
