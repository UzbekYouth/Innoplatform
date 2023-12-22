using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


    }
}
