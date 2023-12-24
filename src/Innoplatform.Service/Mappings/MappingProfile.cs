
using AutoMapper;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Domain.Entities.Educations;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Mentors;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Domain.Entities.Transactions;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.DTOs.Applications;
using Innoplatform.Service.DTOs.Educations;
using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.DTOs.Mentors;
using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.DTOs.OrganizationApplications;
using Innoplatform.Service.DTOs.OrganizationExtraDetails;
using Innoplatform.Service.DTOs.OrganizationInvestment;
using Innoplatform.Service.DTOs.OrganizationInvestmentInvitations;
using Innoplatform.Service.DTOs.OrganizationProjectInvestments;
using Innoplatform.Service.DTOs.Organizations;
using Innoplatform.Service.DTOs.OrganizationSocialMediaLinks;
using Innoplatform.Service.DTOs.ProjectAssets;
using Innoplatform.Service.DTOs.ProjectInvestmentInvitations;
using Innoplatform.Service.DTOs.ProjectInvestments;
using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.RecommendationAreas;
using Innoplatform.Service.DTOs.RecommendationAsset;
using Innoplatform.Service.DTOs.Recommendations;
using Innoplatform.Service.DTOs.Registrations.OrganizationRegistrations;
using Innoplatform.Service.DTOs.Registrations.UserRegistrations;
using Innoplatform.Service.DTOs.Sponsors;
using Innoplatform.Service.DTOs.Transactions;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // AboutUs
        CreateMap<AboutUs, AboutUsForCreationDto>().ReverseMap();
        CreateMap<AboutUs, AboutUsForUpdateDto>().ReverseMap();
        CreateMap<AboutUs, AboutUsForResultDto>().ReverseMap();

        //AboutUsAsset
        CreateMap<AboutUsAsset, AboutUsAssetForCreationDto>().ReverseMap();
        CreateMap<AboutUsAsset, AboutUsAssetForResultDto>().ReverseMap();
        CreateMap<AboutUsAsset, AboutUsAssetForUpdateDto>().ReverseMap();

        //Achievement
        CreateMap<Achievement, AchievementForCreationDto>().ReverseMap();
        CreateMap<Achievement, AchievementForResultDto>().ReverseMap();
        CreateMap<Achievement, AchievementForUpdateDto>().ReverseMap();

        //AchievementAsset
        CreateMap<AchievementAsset, AchievmentAssetsForCreationDto>().ReverseMap();
        CreateMap<AchievementAsset, AchievementAssetsForResultDto>().ReverseMap();
        CreateMap<AchievementAsset, AchievementAssetsForUpdateDto>().ReverseMap();

        //Application
        CreateMap<Application, ApplicationForCreationDto>().ReverseMap();
        CreateMap<Application, ApplicationForResultDto>().ReverseMap();
        CreateMap<Application, ApplicationForUpdateDto>().ReverseMap();

        //Education
        CreateMap<Education, EducationForCreationDto>().ReverseMap();
        CreateMap<Education, EducationForResultDto>().ReverseMap();
        CreateMap<Education, EducationForUpdateDto>().ReverseMap();

        //Investment
        CreateMap<Investment, InvestmentForCreationDto>().ReverseMap();
        CreateMap<Investment, InvestmentForUpdateDto>().ReverseMap();
        CreateMap<Investment, InvestmentForResultDto>().ReverseMap();

        //InvestmentArea
        CreateMap<InvestmentArea, InvestmentAreaForCreationDto>().ReverseMap();
        CreateMap<InvestmentArea, InvestmentAreaForUpdateDto>().ReverseMap();
        CreateMap<InvestmentArea, InvestmentAreaForResultDto>().ReverseMap();

        //Mentor
        CreateMap<Mentor, MentorForCreationDto>().ReverseMap();
        CreateMap<Mentor, MentorForResultDto>().ReverseMap();
        CreateMap<Mentor, MentorForUpdateDto>().ReverseMap();

        //OrganizationExtraDetail
        CreateMap<OrganizationExtraDetails, OrganizationExtraDetailForCreationDto>().ReverseMap();
        CreateMap<OrganizationExtraDetails, OrganizationExtraDetailForResultDto>().ReverseMap();
        CreateMap<OrganizationExtraDetails, OrganizationExtraDetailForUpdateDto>().ReverseMap();

        //OrganizationApplication
        CreateMap<OrganizationApplication, OrganizationApplicationForCreationDto>().ReverseMap();
        CreateMap<OrganizationApplication, OrganizationApplicationForUpdateDto>().ReverseMap();
        CreateMap<OrganizationApplication, OrganizationApplicationForResultDto>().ReverseMap();

        //OrganizationInvestmentInvitation
        CreateMap<OrganizationInvestmentInvitation, OrganizationInvestmentInvitationForResultDto>().ReverseMap();
        CreateMap<OrganizationInvestmentInvitation, OrganizationInvestmentInvitationForCreationDto>().ReverseMap();

        //OrganizationInvestment
        CreateMap<OrganizationInvestment, OrganizationInvestmentForCreationDto>().ReverseMap();
        CreateMap<OrganizationInvestment, OrganizationInvestmentForResultDto>().ReverseMap();
        CreateMap<OrganizationInvestment, OrganizationInvestmentForUpdateDto>().ReverseMap();

        //Organization
        CreateMap<Organization, OrganizationForCreationDto>().ReverseMap();
        CreateMap<Organization, OrganizationForResultDto>().ReverseMap();
        CreateMap<Organization, OrganizationForUpdateDto>().ReverseMap();

        //OrganizationSochialMediaLink
        CreateMap<OrganizationSocialMediaLink, OrganizationSocialMediaLinkForCreationDto>().ReverseMap();
        CreateMap<OrganizationSocialMediaLink, OrganizationSocialMediaLinkForResultDto>().ReverseMap();
        CreateMap<OrganizationSocialMediaLink, OrganizationSocialMediaLinkForUpdateDto>().ReverseMap();

        //OrganizationProjectInvestment

        CreateMap<OrganizationProjectInvestment, OrganizationProjectInvestmentForCreationDto>().ReverseMap();
        CreateMap<OrganizationProjectInvestment, OrganizationProjectInvestmentForResultDto>().ReverseMap();
        CreateMap<OrganizationProjectInvestment, OrganizationProjectInvestmentForUpdateDto>().ReverseMap();

        //Project
        CreateMap<Project, ProjectForCreationDto>().ReverseMap();
        CreateMap<Project, ProjectForResultDto>().ReverseMap();
        CreateMap<Project, ProjectForUpdateDto>().ReverseMap();

        //ProjectAsset
        CreateMap<ProjectAsset, ProjectAssetForCreationDto>().ReverseMap();
        CreateMap<ProjectAsset, ProjectAssetForResultDto>().ReverseMap();
        CreateMap<ProjectAsset, ProjectAssetForUpdateDto>().ReverseMap();

        //ProjectInvestment
        CreateMap<ProjectInvestment, ProjectInvestmentForCreationDto>().ReverseMap();
        CreateMap<ProjectInvestment, ProjectInvestmentForResultDto>().ReverseMap();
        CreateMap<ProjectInvestment, ProjectInvestmentForUpdateDto>().ReverseMap();

        //ProjectInvestmentInvitation
        CreateMap<ProjectInvestmentInvitation, ProjectInvestmentInvitationForCreationDto>().ReverseMap();
        CreateMap<ProjectInvestmentInvitation, ProjectInvestmentInvitationForResultDto>().ReverseMap();
        CreateMap<ProjectInvestmentInvitation, ProjectInvestmentInvitationForUpdateDto>().ReverseMap();

        //RecommondationAsset
        CreateMap<RecommendationAsset, RecommendationAssetForCreationDto>().ReverseMap();
        CreateMap<RecommendationAsset, RecommendationAssetForUpdateDto>().ReverseMap();
        CreateMap<RecommendationAsset, RecommendationAssetForResultDto>().ReverseMap();

        //RecommondationArea
        CreateMap<RecommendationArea, RecommendationAreaForCreationDto>().ReverseMap();
        CreateMap<RecommendationArea, RecommendationAreaForResultDto>().ReverseMap();
        CreateMap<RecommendationArea, RecommendationAreaForUpdateDto>().ReverseMap();

        //Recommondation
        CreateMap<Recommendation, RecommendationForCreationDto>().ReverseMap();
        CreateMap<Recommendation, RecommendationForUpdateDto>().ReverseMap();
        CreateMap<Recommendation, RecommendationForResultDto>().ReverseMap();

        //Sponsor
        CreateMap<Sponsor, SponsorForCreationDto>().ReverseMap();
        CreateMap<Sponsor, SponsorForUpdateDto>().ReverseMap();
        CreateMap<Sponsor, SponsorForResultDto>().ReverseMap();

        //Transaction
        CreateMap<Transaction, TransactionForCreationDto>().ReverseMap();
        CreateMap<Transaction, TransactionForResultDto>().ReverseMap();

        //User
        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();


        //Registration 
        CreateMap<UserForCreationDto, UserRegistrationForCreationDto>().ReverseMap();
        CreateMap<UserForResultDto, UserRegistrationForResultDto>().ReverseMap();

        CreateMap<OrganizationForCreationDto, OrganizationRegistrationForCreationDto>().ReverseMap();
        CreateMap<OrganizationForResultDto, OrganizationRegistrationForResultDto>().ReverseMap();


        //
    }
}
