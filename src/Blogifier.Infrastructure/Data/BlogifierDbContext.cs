using Blogifier.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogifier.Infrastructure.Data;
public class BlogifierDbContext : DbContext
{
    public BlogifierDbContext(DbContextOptions<BlogifierDbContext> options) : base(options) { }

    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
    public DbSet<BlogCategory> BlogCategories => Set<BlogCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogCategory>().HasData(
            new BlogCategory
            {
                Id = 1,
                Name = "Faith"
            },
            new BlogCategory
            {
                Id = 2,
                Name = "Hope"
            },
            new BlogCategory
            {
                Id = 3,
                Name = "Love"
            });

        modelBuilder.Entity<Blog>().HasData(
            new Blog
            {
                Id = 1,
                Title = "The Message",
                SubTitle = "The Daily Message",
                Description = "The invitation from the almighty God to walk before Him: In May 2012 in an extra-ordinary experience the Lord God woke me up from sleep asked me to open my bible to Genesis 17, verses one to eight and spoke to me a very fundamental message that I should send so that it reaches every single person on planet earth. \"Go tell my people I invite them to live their lives in My presence. To those who accept this invitation, I make five solemn promises to them. There are five things however they need to know, believe and experience\". Below are the five solemn promises and the five things you need to know, believe and experience (the needs).This message is sent to you backed by the transforming  power of the Almighty God. Understanding this message will transform your life!"
            });

        modelBuilder.Entity<BlogPost>().HasData(
            new BlogPost
            {
                Id = 1,
                BlogId = 1,
                Title = "Faith Is A Gift Of God",
                Slug = "faith-is-a-gift-of-God",
                Description = "&lt;p&gt;This is your scripture for today, may it empower you. Please share widely and make someone&#39;s day.“But the fruit of the Spirit is love, joy, peace, longsuffering, gentleness, goodness, faith, Meekness, temperance: against such there is no law.”??Galatians? ?5:22-23? ?KJV??.&quot;So faith comes by hearing and hearing by  ...&lt;/p&gt;",
                Content = "In May 2012 in an extra-ordinary experience the Lord God woke me up from sleep asked me to open my bible to Genesis 17, verses one to eight and spoke to me a very fundamental message that I should send so that it reaches every single person on planet earth. \"Go tell my people I invite them to live their lives in My presence. To those who accept this invitation, I make five solemn promises to them. There are five things however they need to know, believe and experience\". Below are the five solemn promises and the five things you need to know, believe and experience (the needs).This message is sent to you backed by the transforming  power of the Almighty God. Understanding this message will transform your life!",
                PublishedOnDate = Convert.ToDateTime("2015-09-21 22:15:00.000"),
                ContentType = BlogContentType.Article,
                BlogCategories = new List<BlogCategory>()
            });
        ;
    }
}
