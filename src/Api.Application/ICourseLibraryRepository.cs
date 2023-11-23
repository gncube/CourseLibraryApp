using Api.Domain;

namespace Api.Application;
public interface ICourseLibraryRepository
{
    //IEnumerable<Author> GetAuthors();
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> GetAuthorAsync(Guid authorId);
    bool AuthorExists(Guid authorId);
    bool Save();
}
