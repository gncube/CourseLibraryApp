using Blogifier.Domain;
using Client.Application.Dtos;

namespace Client.Pages;

public partial class Index
{
    public List<PromoArticleDto> PromoArticles { get; set; } = new List<PromoArticleDto>
    {
        new PromoArticleDto
        {
            Id = 1,
            Title = "Our goal is to be the next billion company. In order to do that, we should work hard.",
            ImageSrc = "assets/img-temp/430x270/img1.jpg",
            Category = "Painting",
            PublishDate = new DateTime(2016, 7, 8),
            Views = 264,
            Likes = 52,
            Shares = 26,
            ContentType = BlogContentType.Image
        },
        new PromoArticleDto
        {
            Id = 2,
            Title = "Why your customer support is very important? Learn the next 10 best tips.",
            ImageSrc = "assets/img-temp/430x270/img2.jpg",
            Category = "Startup",
            PublishDate = new DateTime(2016, 7, 22),
            Views = 127,
            Likes = 152,
            Shares = 32,
            ContentType = BlogContentType.Video
        },
         new PromoArticleDto
        {
             Id = 3,
            Title = "Be ready, fashion of the year is coming this year",
            ImageSrc = "assets/img-temp/400x270/img2.jpg",
            Category = "Spa",
            PublishDate = new DateTime(2017, 7, 26),
            Views = 127,
            Likes = 152,
            Shares = 32,
            ContentType = BlogContentType.Audio
        },
        new PromoArticleDto
        {
            Id = 4,
            Title = "Must be visited places in the USA - Florida Beaches",
            ImageSrc = "assets/img-temp/400x270/img1.jpg",
            Category = "Fashion",
            PublishDate = new DateTime(2017, 7, 18),
            ContentType = BlogContentType.Article
        },
        new PromoArticleDto
        {
            Id = 5,
            Title = "Why your next glass of juice will cost you more",
            ImageSrc = "assets/img-temp/400x270/img17.jpg",
            Category = "Tech",
            PublishDate = new DateTime(2017, 7, 5),
            ContentType = BlogContentType.Article
        }
    };
}
