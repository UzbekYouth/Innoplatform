
using AutoMapper;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Domain.Entities.Educations;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Mentors;
using Innoplatform.Domain.Entities.Messagings;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Domain.Entities.Transactions;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.DTOs.Applications;
using Innoplatform.Service.DTOs.Educations;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.DTOs.Mentors;
using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.DTOs.OrganizationApplications;
using Innoplatform.Service.DTOs.OrganizationExtraDetails;
using Innoplatform.Service.DTOs.OrganizationInvestmentInvitations;
using Innoplatform.Service.DTOs.ProjectAssets;
using Innoplatform.Service.DTOs.ProjectInvestments;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.RecommendationAreas;
using Innoplatform.Service.DTOs.RecommendationAsset;
using Innoplatform.Service.DTOs.Recommendations;
using Innoplatform.Service.DTOs.Sponsors;
using Innoplatform.Service.DTOs.Transactions;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AboutUsAsset, AboutUsAssetForCreationDto>().ReverseMap();
            CreateMap<AboutUsAsset, AboutUsAssetForResultDto>().ReverseMap();
            CreateMap<AboutUsAsset, AboutUsAssetForUpdateDto>().ReverseMap();

            CreateMap<Achievement, AchievementForCreationDto>().ReverseMap();
            CreateMap<Achievement, AchievementForResultDto>().ReverseMap();
            CreateMap<Achievement, AchievementForUpdateDto>().ReverseMap();

            CreateMap<AchievementAsset, AchievementAssetsForCreationDto>().ReverseMap();
            CreateMap<AchievementAsset, AchievementAssetsForResultDto>().ReverseMap();
            CreateMap<AchievementAsset, AchievementAssetsForUpdateDto>().ReverseMap();

            CreateMap<Application, ApplicationForCreationDto>().ReverseMap();
            CreateMap<Application, ApplicationForResultDto>().ReverseMap();
            CreateMap<Application, ApplicationForUpdateDto>().ReverseMap();
            
            CreateMap<Mentor, MentorForCreationDto>().ReverseMap();
            CreateMap<Mentor, MentorForResultDto>().ReverseMap();
            CreateMap<Mentor, MentorForUpdateDto>().ReverseMap();

            CreateMap<Project, ProjectForCreationDto>().ReverseMap();
            CreateMap<Project, ProjectForResultDto>().ReverseMap();
            CreateMap<Project, ProjectForUpdateDto>().ReverseMap();

            CreateMap<ProjectAsset, OrganizationExtraDetailForCreationDto>().ReverseMap();
            CreateMap<ProjectAsset, ProjectAssetForResultDto>().ReverseMap();
            CreateMap<ProjectAsset, ProjectAssetForUpdateDto>().ReverseMap();

            CreateMap<ProjectInvestment, ProjectInvestmentForCreationDto>().ReverseMap();
            CreateMap<ProjectInvestment, ProjectInvestmentForResultDto>().ReverseMap();
            CreateMap<ProjectInvestment, ProjectInvestmentForUpdateDto>().ReverseMap();

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

            CreateMap<RecommendationArea, RecommendationAreaForCreationDto>().ReverseMap();
            CreateMap<RecommendationArea, RecommendationAreaForResultDto>().ReverseMap();
            CreateMap<RecommendationArea, RecommendationAreaForUpdateDto>().ReverseMap();

            CreateMap<Sponsor, SponsorForCreationDto>().ReverseMap();
            CreateMap<Sponsor, SponsorForUpdateDto>().ReverseMap();
            CreateMap<Sponsor, SponsorForResultDto>().ReverseMap();

            CreateMap<Recommendation, RecommendationAssetForCreationDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationAssetForUpdateDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationAssetForResultDto>().ReverseMap();

            CreateMap<Education, EducationForCreationDto>().ReverseMap();
            CreateMap<Education, EducationForUpdateDto>().ReverseMap();
            CreateMap<Education, EducationForResultDto>().ReverseMap();

            CreateMap<OrganizationExtraDetails, OrganizationExtraDetailForResultDto>().ReverseMap();
<<<<<<< HEAD
            CreateMap<OrganizationExtraDetails, OrganizationExtraDetailForCreationDto>().ReverseMap();
=======
            CreateMap<OrganizationExtraDetails, OrganizationExtraDetailForResultDto>().ReverseMap();
>>>>>>> a0db60329ae01489ccc94f8aa234a0a69a902da0
            CreateMap<OrganizationExtraDetails, OrganizationExtraDetailForUpdateDto>().ReverseMap();

            CreateMap<OrganizationApplication, OrganizationApplicationForCreationDto>().ReverseMap();
            CreateMap<OrganizationApplication, OrganizationApplicationForUpdateDto>().ReverseMap();
            CreateMap<OrganizationApplication, OrganizationApplicationForResultDto>().ReverseMap();

            CreateMap<OrganizationInvestmentInvitation, OrganizationInvestmentInvitationForResultDto>().ReverseMap();
            CreateMap<OrganizationInvestmentInvitation, OrganizationInvestmentInvitationForCreationDto>().ReverseMap();
            CreateMap<OrganizationInvestmentInvitation, OrganizationInvestmentInvitationForUpdateDto>().ReverseMap();
        }
    }
}
