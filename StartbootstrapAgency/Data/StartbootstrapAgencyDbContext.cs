using Microsoft.EntityFrameworkCore;
using StartbootstrapAgency.Models;

namespace StartbootstrapAgency.Data
{
    public class StartbootstrapAgencyDbContext : DbContext
    {
        public StartbootstrapAgencyDbContext(DbContextOptions<StartbootstrapAgencyDbContext> options)
            :base(options)
        {

        }

        public DbSet<Masthead> Mastheads { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }


    }
}
