using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.Interfaces;
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

    }
}
