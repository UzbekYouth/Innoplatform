using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.AboutUses;
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
    public class AboutUsService : IAboutUsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AboutUs> _repository;

        public AboutUsService(IRepository<AboutUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AboutUsResultDto> AddAsync(AboutUsForCreationDto dto)
        {
            var aboutUs = await _repository.SelectAll()
                .Where( au => au.Title == dto.Title )
                .AsNoTracking()
                .FirstOrDefaultAsync();
            throw new InnoplatformException(404, "aboutUs is already exist");

            var mappedAboutUs = _mapper.Map<AboutUs>(dto);
            return _mapper.Map<AboutUsResultDto>(await _repository.CreateAsync(mappedAboutUs));
        }

        public Task<IEnumerable<AboutUsResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AboutUsResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AboutUsResultDto> ModifyAsync(long id, AboutUsForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
