using Blogifier.Domain;
using Client.Application.Dtos;
using Microsoft.AspNetCore.Components;

namespace Client.Components;

public partial class BlogCard
{
    [Parameter]
    public BlogPost PromoArticle { get; set; }

    [Parameter]
    public EventCallback<BlogPost> BlogPostViewClicked { get; set; }

    private void OnBlogPostViewClicked()
    {
        BlogPostViewClicked.InvokeAsync(PromoArticle);
    }
}
