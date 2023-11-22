using Blogifier.Domain;

namespace Blogifier.Application.Dtos;
public class BlogPostCreateDto
{
    public int BlogId { get; set; }
    public string Title { get; set; } = "";
    public string Slug { get; set; } = "";
    public string Description { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime PublishedOnDate { get; set; }

    public BlogContentType ContentType { get; set; }
    public ICollection<BlogCategory> Categories { get; set; }
}
