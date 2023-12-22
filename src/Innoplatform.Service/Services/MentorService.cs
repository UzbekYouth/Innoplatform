using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Mentors;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.Mentors;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Mentor> _repository;

        public MentorService(IMapper mapper, IRepository<Mentor> repository)
        {
            _mapper = mapper;
            _repository = repository;
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

            var mappedEntity = _mapper.Map<Mentor>(dto);
            return _mapper.Map<MentorForResultDto>(await _repository
                .CreateAsync(mappedEntity));
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

        public async Task<MentorForResultDto> ModifyAsync(long id, MentorForCreationDto dto)
        {
            var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
            if (entity == null)
                throw new InnoplatformException(404, "mentor is not found");

            var mappedEntity = _mapper.Map(dto,entity);
            mappedEntity.UpdatedAt = DateTime.UtcNow;

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
}
