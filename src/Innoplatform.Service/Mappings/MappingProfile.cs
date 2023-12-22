
using AutoMapper;
using Innoplatform.Domain.Entities;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.DTOs.Messages;
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
        }
    }
}
