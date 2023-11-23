using Api.Application;
using Api.Domain;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infrastructure;

public class CourseLibraryRepository : ICourseLibraryRepository
{
    private readonly ILogger _logger;
    private readonly CourseLibraryContext _context;

    public CourseLibraryRepository(ILoggerFactory loggerFactory, CourseLibraryContext context)
    {
        _logger = loggerFactory.CreateLogger<CourseLibraryRepository>();
        _context = context;
        _context.Database.EnsureCreated();
    }
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthorAsync(Guid authorId)
    {
        var authorFromContext = await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
        if (authorFromContext == null)
        {
            _logger.LogInformation($"Author with id: {authorId} not found");
            throw new Exception($"Author with id: {authorId} not found");
        }
        return authorFromContext;
    }

    public bool AuthorExists(Guid authorId)
    {
        return _context.Authors.Any(a => a.Id == authorId);
    }

    public bool Save()
    {
        return (_context.SaveChanges() >= 0);
    }
}