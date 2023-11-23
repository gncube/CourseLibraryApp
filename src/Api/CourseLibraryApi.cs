using Api.Application;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Api;

public class CourseLibraryApi
{
    private readonly ILogger _logger;
    private readonly ICourseLibraryRepository _repo;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public CourseLibraryApi(ILoggerFactory loggerFactory, ICourseLibraryRepository repo, JsonSerializerOptions jsonSerializerOptions)
    {
        _logger = loggerFactory.CreateLogger<CourseLibraryApi>();
        _repo = repo;
        _jsonSerializerOptions = jsonSerializerOptions;
    }

    [Function(nameof(AuthorsGetAsync))]
    public async Task<HttpResponseData> AuthorsGetAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "authors")] HttpRequestData req)
    {
        _logger.LogInformation("---> {FunctionName} function processed a request.", nameof(AuthorsGetAsync));

        try
        {
            var authorsFromRepo = await _repo.GetAuthorsAsync();
            return AzureFunctionsHelpers.CreateHttpResponseData(req, authorsFromRepo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting authors");
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
