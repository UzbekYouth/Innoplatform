using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Mentors;
using Innoplatform.Domain.Entities.Messagings;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Domain.Entities.Transactions;
using Innoplatform.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        //About Us
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<AboutUsAsset> AboutUsAssets { get; set; }

        //Achievments
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementAsset> AchievementAssets { get; set; }

        //Investments
        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentArea> InvestmentAreas { get; set; }

        //Mentors
        public DbSet<Mentor> Mentors { get; set; }

        //Messaging
        public DbSet<Messaging> Messages { get; set; }

        //Organization
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationApplication> OrganizationApplications { get; set; }
        public DbSet<OrganizationExtraDetails> OrganizationExtraDetails { get; set; }
        public DbSet<OrganizationInvestment> OrganizationInvestments { get; set; }
        public DbSet<OrganizationInvestmentInvitation> OrganizationInvestmentInvitations { get; set; }
        public DbSet<OrganizationProjectInvestment> OrganizationProjectInvestments { get; set; }
        public DbSet<OrganizationSocialMediaLink> OrganizationSocialMediaLinks { get; set; }


        //Projects
        public DbSet<Application> Applications { get; set; }
        public DbSet<Project> Projects { get;set; }
        public DbSet<ProjectAsset> ProjectAssets { get; set; }
        public DbSet<ProjectInvestment> ProjectInvestments { get; set; }
        public DbSet<ProjectInvestmentInvitation> ProjectInvestmentInvitations { get; set; }

        //Recommendations
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<RecommendationAsset> RecommendationAssets { get; set; }
        public DbSet<RecommendationArea> RecommendationAreas { get; set; }


        //Sponsers
        public DbSet<Sponsor> Sponsors { get; set; }

        //Transactions
        public DbSet<Transaction> Transactions { get; set; }

        //User
        public DbSet<User> Users { get; set; }


        

    }
}
