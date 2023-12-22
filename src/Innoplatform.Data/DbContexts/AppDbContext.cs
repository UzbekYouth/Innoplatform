using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Investments;
using Innoplatform.Domain.Entities.Messagings;
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


        DbSet<Investment> Investments { get; set; }
        DbSet<InvestmentArea> InvestmentAreas { get; set; }
        DbSet<Messaging> Messages { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Application> Applications { get; set; }
        DbSet<ProjectInvestment> ProjectInvestments { get; set; }
        DbSet<Project> Projects { get;set; }
        DbSet<ProjectAsset> ProjectAssets { get; set; }
        DbSet<AboutUsAsset> AboutUsAssets { get; set; }
        DbSet<Recommendation> Recommendations { get; set; }
        DbSet<RecommendationAsset> RecommendationAssets { get; set; }
        DbSet<Sponsor> Sponsors { get; set;}
        

    }
}
