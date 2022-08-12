using backendRCVUcab.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace RCVUcabBackend.Persistence
{
    public class DesignTimeDbContextFactory
    {
        public RCVDbContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<RCVDbContext>();
            var connectionString = "Server=PostgreSQL 14;Host=127.0.0.1;Database=providerDB;Username=postgres;Password=3004092";
            builder.UseNpgsql(connectionString);
            return new RCVDbContext(builder.Options);
        }
    }
}