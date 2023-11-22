namespace Client.Application.Dtos;
public class BlogPostReadDto : PromoArticleDto
{
    public string Description { get; set; }
    public string Content { get; set; }
    public DateTime PublishedOnDate { get; set; }
}
