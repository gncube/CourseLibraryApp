using Blogifier.Application;
using Blogifier.Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Api.Api;

public class BlogApi
{
    private readonly ILogger _logger;
    private readonly IRepository<Blog, int> _repo;

    public BlogApi(ILoggerFactory loggerFactory, IRepository<Blog, int> repo)
    {
        _logger = loggerFactory.CreateLogger<BlogApi>();
        _repo = repo;
    }

    [Function(nameof(BlogsGet))]
    public async Task<HttpResponseData> BlogsGet([HttpTrigger(AuthorizationLevel.Function, "get", Route = "blogs")] HttpRequestData req)
    {
        _logger.LogInformation("---> {FunctionName} function processed a request.", nameof(BlogsGet));

        try
        {
            var blogs = await _repo.GetAllAsync();
            return AzureFunctionsHelpers.CreateHttpResponseData(req, blogs);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting blogs");
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
