using Blogifier.Application;
using Blogifier.Domain;
using Blogifier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blogifier.Infrastructure;
public class BlogRepository : IRepository<Blog, int>
{
    private readonly BlogifierDbContext _context;

    public BlogRepository(BlogifierDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreatedAsync();
    }
    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _context.Blogs.ToListAsync();
    }

    public Task<Blog> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Blog> AddAsync(Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
