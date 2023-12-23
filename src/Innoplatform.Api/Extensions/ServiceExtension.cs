using Innoplatform.Data.IRepositories;
using Innoplatform.Data.Repositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IAboutServices;
using Innoplatform.Service.Interfaces.IAchievmentServices;
using Innoplatform.Service.Interfaces.IAuthServices;
using Innoplatform.Service.Interfaces.IEducationServices;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IInvestmentServices;
using Innoplatform.Service.Interfaces.IMentorServices;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Innoplatform.Service.Interfaces.IProjectServices;
using Innoplatform.Service.Interfaces.ISponsorServices;
using Innoplatform.Service.Interfaces.ITransactionServices;
using Innoplatform.Service.Interfaces.IUserServices;
using Innoplatform.Service.Mappings;
using Innoplatform.Service.Services;
using Innoplatform.Service.Services.AboutServices;
using Innoplatform.Service.Services.AchievmentServices;
using Innoplatform.Service.Services.AuthServices;
using Innoplatform.Service.Services.EducationServices;
using Innoplatform.Service.Services.FileUploadServices;
using Innoplatform.Service.Services.InvestmentServices;
using Innoplatform.Service.Services.MessagingServices;
using Innoplatform.Service.Services.OrganizationServices;
using Innoplatform.Service.Services.ProjectServices;
using Innoplatform.Service.Services.RecommendationServices;
using Innoplatform.Service.Services.SponsorServices;
using Innoplatform.Service.Services.TransactionServices;
using Innoplatform.Service.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace Innoplatform.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            // Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // About services
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IAboutUsAssetService, AboutUsAssetService>();

            //Achievement services
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddScoped<IAchievementAssetService, AchievementAssetService>();

            // Auth service
            services.AddScoped<IAuthService, AuthService>();

            // Education service
            services.AddScoped<IEducationService, EducationService>();

            //FileUpload service
            services.AddScoped<IFileUploadService, FileUploadService>();

            // Investment services
            services.AddScoped<IInvestmentAreaService, InvestmentAreaService>();
            services.AddScoped<IInvestmentService, InvestmentService>();

            // Mentor service
            services.AddScoped<IMentorService, MentorService>();

            // Messaging service
            services.AddScoped<IMessagingService, MessagingService>();

            // Organization services
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IOrganizationInvestmentService, OrganizationInvestmentService>();
            services.AddScoped<IOrganizationApplicationService, OrganizationApplicationService>();
            services.AddScoped<IOrganizationExtraDetailService, OrganizationExtraDetailService>();
            services.AddScoped<IOrganizationSocialMediaLinkService, OrganizationSocialMediaLinksService>();
            services.AddScoped<IOrganizationProjectInvestmentService, OrganizationProjectInvestmentService>();
            services.AddScoped<IOrganizationInvestmentInvitationService, OrganizationInvestmentInvitationService>();

            // Project services
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IProjectAssetService, ProjectAssetService>();
            services.AddScoped<IProjectInvestmentService, ProjectInvestmentService>();
            services.AddScoped<IProjectInvestmentInvitationService, ProjectInvestmentInvitationService>();

            // Recommondation services
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<IRecommendationAreaService, RecommendationAreaService>();
            services.AddScoped<IRecommendationAssetService, RecommendationAssetService>();

            // Sponsor service
            services.AddScoped<ISponsorService, SponsorService>();

            // Transaction service
            services.AddScoped<ITransactionService, TransactionService>();

            //User service
            services.AddScoped<IUserService, UserService>();

            // Automapper
            services.AddAutoMapper(typeof(MappingProfile));


        }

        public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Innoplatform.Api", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
        }
    }
}
