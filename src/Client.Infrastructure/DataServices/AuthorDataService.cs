using Api.Domain;
using Client.Application.Contracts;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Client.Infrastructure.DataServices;
public class AuthorDataService : IDataService<Author, Guid>
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ILogger _logger;

    public AuthorDataService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions, ILoggerFactory loggerFactory)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
        _logger = loggerFactory.CreateLogger<AuthorDataService>();
    }
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        using var responseStream = await _httpClient.GetStreamAsync("api/authors");
        using var streamReader = new StreamReader(responseStream);
        var authorsFromApi = await JsonSerializer.DeserializeAsync<IEnumerable<Author>>(streamReader.BaseStream, _jsonSerializerOptions);

        if (authorsFromApi is null)
        {
            _logger.LogError("Could not deserialize authors from API");
            throw new Exception("Could not deserialize authors from API");
        }

        return authorsFromApi;
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
