using Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Data;

public class CourseLibraryContext : DbContext
{
    public CourseLibraryContext(DbContextOptions<CourseLibraryContext> options) : base(options) { }

    public DbSet<Author> Authors => Set<Author>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data
        modelBuilder.Entity<Author>().HasData(
            new Author()
            {
                Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                FirstName = "Berry",
                LastName = "Griffin Beak Eldritch",
                DateOfBirth = new DateTime(1968, 11, 23),
                MainCategory = "Ships"
            },
            new Author()
            {
                Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                FirstName = "Eli",
                LastName = "Ivory Bones Sweet",
                DateOfBirth = new DateTime(1990, 12, 23),
                MainCategory = "Cars"
            },
            new Author()
            {
                Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                FirstName = "Nancy",
                LastName = "Swashbuckler Rye",
                DateOfBirth = new DateTime(1992, 10, 3),
                MainCategory = "Planes"
            },
            new Author()
            {
                Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                FirstName = "Tony",
                LastName = "Stark",
                DateOfBirth = new DateTime(1970, 1, 20),
                MainCategory = "Planes"
            },
            new Author()
            {
                Id = Guid.Parse("b58982c1-cc7c-4d53-b07e-adeb1bac000d"),
                FirstName = "Jenny",
                LastName = "Doe",
                DateOfBirth = new DateTime(1989, 7, 30),
                MainCategory = "Planes"
            }
            );

        base.OnModelCreating(modelBuilder);
    }
}