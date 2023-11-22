using Blogifier.Domain;
using Client.Application.Contracts;
using Microsoft.AspNetCore.Components;

namespace Client.Pages;

public partial class BlogPosts
{
    [Inject]
    public IDataService<BlogPost, int>? BlogPostService { get; set; }

    public IEnumerable<BlogPost>? BlogPostList { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (BlogPostService is null)
        {
            throw new Exception("BlogPostService dependency is null");
        }

        var blogPostsArray = await BlogPostService.GetAllAsync();

        if (blogPostsArray is not null)
        {
            BlogPostList = await BlogPostService!.GetAllAsync();
        }
    }
}
