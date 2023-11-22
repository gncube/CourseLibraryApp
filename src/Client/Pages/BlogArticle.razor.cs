using Blogifier.Domain;
using Client.Application.Contracts;
using Microsoft.AspNetCore.Components;

namespace Client.Pages;

public partial class BlogArticle
{
    [Inject]
    public IDataService<BlogPost, int>? BlogPostService { get; set; }

    [Parameter]
    public int Id { get; set; }

    public BlogPost? BlogPostArticle { get; set; } = new BlogPost();

    protected override async Task OnInitializedAsync()
    {
        if (BlogPostService is null)
        {
            throw new Exception("BlogPostService dependency is null");
        }

        BlogPostArticle = await BlogPostService!.GetAsync(Id);
    }
}
