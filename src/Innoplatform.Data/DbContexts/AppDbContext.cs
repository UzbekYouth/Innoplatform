using Innoplatform.Domain.Entities;
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
