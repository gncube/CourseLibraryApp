using Blogifier.Application;
using Blogifier.Domain;
using Blogifier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blogifier.Infrastructure;

public class BlogPostRepository : IRepository<BlogPost, int>
{
    private readonly BlogifierDbContext _context;

    public BlogPostRepository(BlogifierDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreatedAsync();
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _context.BlogPosts.Include(p => p.BlogCategories).ToListAsync();
    }

    public Task<BlogPost> GetAsync(int id)
    {
        var foundBlogPost = _context.BlogPosts.Include(p => p.BlogCategories).FirstOrDefaultAsync(x => x.Id == id);
        if (foundBlogPost is null)
        {
            throw new Exception($"BlogPost with id {id} does not exist");
        }

        return foundBlogPost;
    }

    public async Task<BlogPost> AddAsync(BlogPost post)
    {
        var blogExists = await _context.Blogs.AnyAsync(x => x.Id == post.BlogId);
        if (!blogExists)
        {
            throw new Exception($"Blog with id {post.BlogId} does not exist");
        }

        var addedBlogPost = await _context.BlogPosts.AddAsync(post);
        var blogPost = addedBlogPost.Entity;
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public Task<bool> UpdateAsync(BlogPost entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}