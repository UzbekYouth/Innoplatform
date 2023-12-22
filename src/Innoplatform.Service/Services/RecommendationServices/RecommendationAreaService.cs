using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Service.DTOs.RecommendationAreas;
using Innoplatform.Service.Interfaces;

namespace Innoplatform.Service.Services.RecommendationServices;

public class RecommendationAreaService : IRecommendationAreaService
{
    private readonly IMapper _mapper;
    private readonly IRepository<RecommendationArea> _recommendationAreaRepository;

    public RecommendationAreaService(IMapper mapper, IRepository<RecommendationArea> recommendationAreaRepository)
    {
        _mapper = mapper;
        _recommendationAreaRepository = recommendationAreaRepository;
    }

    public Task<RecommendationAreaForResultDto> AddAsync(RecommendationAreaForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecommendationAreaForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RecommendationAreaForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<RecommendationAreaForResultDto> ModifyAsync(long id, RecommendationAreaForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
