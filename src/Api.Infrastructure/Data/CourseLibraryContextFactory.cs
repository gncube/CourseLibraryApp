using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infrastructure.Data;
public class CourseLibraryContextFactory : IDesignTimeDbContextFactory<CourseLibraryContext>
{
    public CourseLibraryContext CreateDbContext(string[] args)
    {
        var home = Environment.GetEnvironmentVariable("HOME") ?? "";
        var databasePath = Path.Combine(home, "CourseLibraryDB.sqlite");

        var optionsBuilder = new DbContextOptionsBuilder<CourseLibraryContext>();
        optionsBuilder.UseSqlite($"Data Source={databasePath}");

        return new CourseLibraryContext(optionsBuilder.Options);
    }
}

