using Api.Domain;
using Client.Application.Contracts;
using Microsoft.AspNetCore.Components;

namespace Client.Pages;

public partial class Books
{
    [Inject]
    public IDataService<Author, Guid>? AuthorDataService { get; set; }

    public IEnumerable<Author>? Authors { get; set; } = new List<Author>();

    protected override async Task OnInitializedAsync()
    {
        Authors = await AuthorDataService!.GetAllAsync();
    }
}
