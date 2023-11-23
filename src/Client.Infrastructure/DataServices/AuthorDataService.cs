using Api.Application.Helpers;
using Api.Domain;
using Blazored.LocalStorage;
using Client.Application.Contracts;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Client.Infrastructure.DataServices;
public class AuthorDataService : IDataService<Author, Guid>
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ILocalStorageService _localStorageService;
    private readonly ILogger _logger;

    public AuthorDataService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions, ILocalStorageService localStorageService, ILoggerFactory loggerFactory)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
        _localStorageService = localStorageService;
        _logger = loggerFactory.CreateLogger<AuthorDataService>();
    }
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        var refreshRequired = false;

        try
        {
            if (!refreshRequired)
            {
                bool authorListExpirationKeyExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.AuthorListExpirationKey);
                if (authorListExpirationKeyExists)
                {
                    var expirationDate = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.AuthorListExpirationKey);
                    if (expirationDate > DateTime.Now)
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.AuthorListKey))
                        {
                            return await _localStorageService.GetItemAsync<IEnumerable<Author>>(LocalStorageConstants.AuthorListKey);
                        }
                    }
                }
            }

            using var responseStream = await _httpClient.GetStreamAsync("api/authors");
            using var streamReader = new StreamReader(responseStream);
            var authorsFromApi = await JsonSerializer.DeserializeAsync<IEnumerable<Author>>(streamReader.BaseStream, _jsonSerializerOptions);

            if (authorsFromApi is null)
            {
                _logger.LogError("Could not deserialize authors from API");
                throw new Exception("Could not deserialize authors from API");
            }

            await _localStorageService.SetItemAsync(LocalStorageConstants.AuthorListKey, authorsFromApi);
            await _localStorageService.SetItemAsync(LocalStorageConstants.AuthorListExpirationKey, DateTime.Now.AddMinutes(5));

            return authorsFromApi;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error in {FunctionName} getting authors from API", nameof(GetAllAsync));
            return Enumerable.Empty<Author>();
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Could not deserialize authors from API");
            return Enumerable.Empty<Author>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {FunctionName} getting authors from API", nameof(GetAllAsync));
            return Enumerable.Empty<Author>();
        }
    }

    public Task<Author> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Author> AddAsync(Author entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Author entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
