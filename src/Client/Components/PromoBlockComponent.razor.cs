using Client.Application.Dtos;
using Microsoft.AspNetCore.Components;

namespace Client.Components;

public partial class PromoBlockComponent
{
    [Parameter]
    public List<PromoArticleDto> PromoArticles { get; set; }

    [Parameter]
    public EventCallback<PromoArticleDto> BlogPostViewClicked { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public List<PromoArticleDto> LeadingPromoArticles { get; set; }
    public List<PromoArticleDto> FollowingPromoArticles { get; set; }

    protected override void OnInitialized()
    {
        LeadingPromoArticles = PromoArticles.Take(2).ToList();
        FollowingPromoArticles = PromoArticles.Skip(2).ToList();
    }
    private void OnBlogPostViewClicked(PromoArticleDto promoArticleDto)
    {
        // Navigate to the blog post view page
        NavigationManager.NavigateTo($"blog/{promoArticleDto.Id}");
    }
}
