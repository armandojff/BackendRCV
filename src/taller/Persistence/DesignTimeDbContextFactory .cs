using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RCVUcabBackend.Persistence.Database;

namespace RCVUcabBackend.Persistence{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<TallerDbContext>
    {
        public TallerDbContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<TallerDbContext>();
            var connectionString = "Server=PostgreSQL 13;Database=bdTaller;Host=localhost;Username=postgres;Password=123456789102sd";
            builder.UseNpgsql(connectionString);
            return new TallerDbContext(builder.Options);
        }
    }
}