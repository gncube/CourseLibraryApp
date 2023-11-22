using Blogifier.Domain;

namespace Client.Application.Dtos;
public class PromoArticleDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageSrc { get; set; }
    public string Category { get; set; }
    public DateTime PublishDate { get; set; }
    public int Views { get; set; }
    public int Likes { get; set; }
    public int Shares { get; set; }

    public BlogContentType ContentType { get; set; }
}
