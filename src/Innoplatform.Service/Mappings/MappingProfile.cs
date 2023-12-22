
using AutoMapper;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Messagings;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Domain.Entities.Transactions;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.DTOs.RecommendationAsset;
using Innoplatform.Service.DTOs.Sponsors;
using Innoplatform.Service.DTOs.Transactions;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();

            CreateMap<Investment, InvestmentForCreationDto>().ReverseMap();
            CreateMap<Investment, InvestmentForUpdateDto>().ReverseMap();
            CreateMap<Investment, InvestmentForResultDto>().ReverseMap();

            CreateMap<InvestmentArea, InvestmentAreaForCreationDto>().ReverseMap();
            CreateMap<InvestmentArea, InvestmentAreaForUpdateDto>().ReverseMap();
            CreateMap<InvestmentArea, InvestmentAreaForResultDto>().ReverseMap();

            CreateMap<Messaging, MessagingForCreationDto>().ReverseMap();
            CreateMap<Messaging, MessagingForUpdateDto>().ReverseMap();
            CreateMap<Messaging, MessagingForResultDto>().ReverseMap();

            CreateMap<Transaction, TransactionForCreationDto>().ReverseMap();
            CreateMap<Transaction, TransactionForResultDto>().ReverseMap();

            CreateMap<AboutUsAsset, AboutUsAssetForCreationDto>().ReverseMap();
            CreateMap<AboutUsAsset, AboutUsAssetForUpdateDto>().ReverseMap();
            CreateMap<AboutUsAsset, AboutUsAssetForResultDto>().ReverseMap();

            CreateMap<RecommendationAsset, RecommendationAssetForCreationDto>().ReverseMap();
            CreateMap<RecommendationAsset, RecommendationAssetForUpdateDto>().ReverseMap();
            CreateMap<RecommendationAsset, RecommendationAssetForResultDto>().ReverseMap();

            CreateMap<Sponsor, SponsorForCreationDto>().ReverseMap();
            CreateMap<Sponsor, SponsorForUpdateDto>().ReverseMap();
            CreateMap<Sponsor, SponsorForResultDto>().ReverseMap();

            CreateMap<Recommendation, RecommendationAssetForCreationDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationAssetForUpdateDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationAssetForResultDto>().ReverseMap();


        }
    }
}
