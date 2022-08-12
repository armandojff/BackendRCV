using administrador.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace administrador
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RCVDbContext>
    {
        public RCVDbContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<RCVDbContext>();
            var connectionString = "Server=PostgreSQL 13;Database=bdAdmin;Host=localhost;Username=postgres;Password=123456789102sd";
            builder.UseNpgsql(connectionString);
            return new RCVDbContext(builder.Options);
        }
    }
}