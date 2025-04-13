using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskGear.Infrastructure.Sqlite;

public class DesignTimeFactory : IDesignTimeDbContextFactory<SqliteContext>
{
    public SqliteContext CreateDbContext(string[] args)
    {
       var optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();

        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();

        string? connectionString = config.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlite(connectionString);

        return new SqliteContext(optionsBuilder.Options);
    }
}