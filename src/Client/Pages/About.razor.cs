namespace Client.Pages;

public partial class About
{
    string NameFromLocalStorage { get; set; }
    string StringFromLocalStorage { get; set; }
    int ItemsInLocalStorage { get; set; }
    string Name { get; set; }
    bool ItemExist { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await GetNameFromLocalStorage();
        await GetStringFromLocalStorage();
        await GetLocalStorageLength();

        localStorage.Changed += (sender, e) =>
        {
            Console.WriteLine($"Value for key {e.Key} changed from {e.OldValue} to {e.NewValue}");
        };
    }

    async Task SaveName()
    {
        await localStorage.SetItemAsync("name", Name);
        await GetNameFromLocalStorage();
        await GetStringFromLocalStorage();
        await GetLocalStorageLength();

        Name = "";
    }

    async Task GetNameFromLocalStorage()
    {
        try
        {
            NameFromLocalStorage = await localStorage.GetItemAsync<string>("name");

            if (string.IsNullOrEmpty(NameFromLocalStorage))
            {
                NameFromLocalStorage = "Nothing Saved";
            }
        }
        catch (Exception)
        {
            Console.WriteLine("error reading 'name'");
        }
    }


    async Task GetStringFromLocalStorage()
    {
        StringFromLocalStorage = await localStorage.GetItemAsStringAsync("name");

        if (string.IsNullOrEmpty(StringFromLocalStorage))
        {
            StringFromLocalStorage = "Nothing Saved";
        }
    }

    async Task RemoveName()
    {
        await localStorage.RemoveItemAsync("name");
        await GetNameFromLocalStorage();
        await GetStringFromLocalStorage();
        await GetLocalStorageLength();
    }

    async Task ClearLocalStorage()
    {
        Console.WriteLine("Calling Clear...");
        await localStorage.ClearAsync();
        Console.WriteLine("Getting name from local storage...");
        await GetNameFromLocalStorage();
        await GetStringFromLocalStorage();
        Console.WriteLine("Calling Get Length...");
        await GetLocalStorageLength();
    }

    async Task GetLocalStorageLength()
    {
        Console.WriteLine(await localStorage.LengthAsync());
        ItemsInLocalStorage = await localStorage.LengthAsync();
        ItemExist = await localStorage.ContainKeyAsync("name");
    }
}
