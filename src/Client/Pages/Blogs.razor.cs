using Blogifier.Domain;
using Client.Application.Contracts;
using Microsoft.AspNetCore.Components;

namespace Client.Pages;

public partial class Blogs
{
    [Inject]
    public IDataService<Blog, int>? BlogService { get; set; }

    public IEnumerable<Blog>? BlogList { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (BlogService is null)
        {
            throw new Exception("BlogService dependency is null");
        }

        var blogsArray = await BlogService.GetAllAsync();

        if (blogsArray is not null)
        {
            BlogList = await BlogService!.GetAllAsync();
        }
    }
}
