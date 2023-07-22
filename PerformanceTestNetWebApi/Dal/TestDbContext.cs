using Microsoft.EntityFrameworkCore;

namespace PerformanceTestNetWebApi.Dal
{
    public class TestDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=TestDataBase;Username=cliff;Password=Abc12345[}");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
