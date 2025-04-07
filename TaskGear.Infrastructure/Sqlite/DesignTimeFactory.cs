using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskGear.Infrastructure.Sqlite;

public class DesignTimeFactory : IDesignTimeDbContextFactory<SqliteContext>
{
    public SqliteContext CreateDbContext(string[] args)
    {
        var dbPath = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(dbPath);
        var db = Path.Join(path, "task_gear.db");

        var builder = new DbContextOptionsBuilder<SqliteContext>();
        builder.UseSqlite($"Data Source={db}");

        return new SqliteContext(builder.Options);
    }
}