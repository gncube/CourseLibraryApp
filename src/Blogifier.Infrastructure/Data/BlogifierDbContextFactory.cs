using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blogifier.Infrastructure.Data;
public class BlogifierDbContextFactory : IDesignTimeDbContextFactory<BlogifierDbContext>
{
    public BlogifierDbContext CreateDbContext(string[] args)
    {
        var home = Environment.GetEnvironmentVariable("HOME") ?? "";
        var databasePath = Path.Combine(home, "BlogifierDb.sqlite");

        var optionsBuilder = new DbContextOptionsBuilder<BlogifierDbContext>();
        optionsBuilder.UseSqlite($"Data Source={databasePath}");

        return new BlogifierDbContext(optionsBuilder.Options);
    }
}

