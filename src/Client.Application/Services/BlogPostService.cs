using Blazored.LocalStorage;
using Blogifier.Domain;
using Client.Application.Contracts;
using Client.Application.Helpers;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Client.Application.Services;
public class BlogPostService : IDataService<BlogPost, int>
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ILocalStorageService _localStorageService;
    private readonly ILogger<BlogPostService> _logger;

    public BlogPostService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions, ILocalStorageService localStorageService, ILogger<BlogPostService> logger)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
        _localStorageService = localStorageService;
        _logger = logger;
    }
    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        var refreshRequired = false;

        try
        {
            if (!refreshRequired)
            {
                bool blogPostExpirationKeyExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.BlogPostListExpirationKey);
                if (blogPostExpirationKeyExists)
                {
                    var expirationDate = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.BlogPostListExpirationKey);
                    if (expirationDate > DateTime.Now)
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.BlogPostsListKey))
                        {
                            return await _localStorageService.GetItemAsync<IEnumerable<BlogPost>>(LocalStorageConstants.BlogPostsListKey);
                        }
                    }
                }
            }

            using var responseStream = await _httpClient.GetStreamAsync("api/blogposts");
            using var streamReader = new StreamReader(responseStream);
            var blogPosts = await JsonSerializer.DeserializeAsync<IEnumerable<BlogPost>>(streamReader.BaseStream, _jsonSerializerOptions)!;

            await _localStorageService.SetItemAsync(LocalStorageConstants.BlogPostsListKey, blogPosts);
            await _localStorageService.SetItemAsync(LocalStorageConstants.BlogPostListExpirationKey, DateTime.Now.AddMinutes(5));

            return blogPosts!;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAllAsync));
            throw new Exception("Failed to retrieve blogPosts from the server.", ex);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAllAsync));
            throw new Exception("Failed to deserialize the response from the server.", ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAllAsync));
            return new List<BlogPost>();
        }
    }

    public async Task<BlogPost> GetAsync(int id)
    {
        try
        {
            bool blogPostKeyExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.BlogPostKey + id);
            if (blogPostKeyExists)
            {
                return await _localStorageService.GetItemAsync<BlogPost>(LocalStorageConstants.BlogPostKey + id);
            }

            using var responseStream = await _httpClient.GetStreamAsync($"api/blogposts/{id}");
            using var streamReader = new StreamReader(responseStream);
            var blogPost = await JsonSerializer.DeserializeAsync<BlogPost>(streamReader.BaseStream, _jsonSerializerOptions)!;

            await _localStorageService.SetItemAsync(LocalStorageConstants.BlogPostKey + id, blogPost);

            return blogPost!;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAsync));
            throw new Exception("Failed to retrieve blogPost from the server.", ex);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAsync));
            throw new Exception("Failed to deserialize the response from the server.", ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {Method}", nameof(GetAsync));
            return new BlogPost();
        }
    }

    public Task<BlogPost> AddAsync(BlogPost entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(BlogPost entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
