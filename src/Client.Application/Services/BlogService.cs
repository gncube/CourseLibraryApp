using Blazored.LocalStorage;
using Blogifier.Domain;
using Client.Application.Contracts;
using Client.Application.Helpers;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Client.Application.Services;
public class BlogService : IDataService<Blog, int>
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ILocalStorageService _localStorageService;
    private readonly ILogger<BlogService> _logger;

    public BlogService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions, ILocalStorageService localStorageService, ILogger<BlogService> logger)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
        _localStorageService = localStorageService;
        _logger = logger;
    }
    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        var refreshRequired = false;

        try
        {
            if (!refreshRequired)
            {
                bool blogExpirationKeyExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.BlogListExpirationKey);
                if (blogExpirationKeyExists)
                {
                    var expirationDate = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.BlogListExpirationKey);
                    if (expirationDate > DateTime.Now)
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.BlogsListKey))
                        {
                            return await _localStorageService.GetItemAsync<IEnumerable<Blog>>(LocalStorageConstants.BlogsListKey);
                        }
                    }
                }
            }

            using var responseStream = await _httpClient.GetStreamAsync("api/blogs");
            using var streamReader = new StreamReader(responseStream);
            var blogs = await JsonSerializer.DeserializeAsync<IEnumerable<Blog>>(streamReader.BaseStream, _jsonSerializerOptions)!;

            await _localStorageService.SetItemAsync(LocalStorageConstants.BlogsListKey, blogs);
            await _localStorageService.SetItemAsync(LocalStorageConstants.BlogListExpirationKey, DateTime.Now.AddMinutes(5));

            return blogs!;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAllAsync));
            throw new Exception("Failed to retrieve blogs from the server.", ex);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAllAsync));
            throw new Exception("Failed to deserialize the response from the server.", ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAllAsync));
            return new List<Blog>();
        }
    }

    public Task<Blog> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Blog> AddAsync(Blog blog)
    {
        var blogJson = new StringContent(JsonSerializer.Serialize(blog), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/blogs", blogJson);

        if (response.IsSuccessStatusCode)
        {
            var createdBlog = await JsonSerializer.DeserializeAsync<Blog>(await response.Content.ReadAsStreamAsync());
            return createdBlog!;
        }
        return null;
    }

    public Task<bool> UpdateAsync(Blog entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
