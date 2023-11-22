using Blogifier.Application;
using Blogifier.Application.Dtos;
using Blogifier.Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Api.Api;

public class BlogPostApi
{
    private readonly ILogger _logger;
    private readonly IRepository<BlogPost, int> _repo;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public BlogPostApi(ILoggerFactory loggerFactory, IRepository<BlogPost, int> repo, JsonSerializerOptions jsonSerializerOptions)
    {
        _logger = loggerFactory.CreateLogger<BlogPostApi>();
        _repo = repo;
        _jsonSerializerOptions = jsonSerializerOptions;
    }

    [Function(nameof(BlogPostsGet))]
    public async Task<HttpResponseData> BlogPostsGet([HttpTrigger(AuthorizationLevel.Function, "get", Route = "blogposts")] HttpRequestData req)
    {
        _logger.LogInformation("---> {FunctionName} function processed a request.", nameof(BlogPostsGet));

        try
        {
            var blogPosts = await _repo.GetAllAsync();
            return AzureFunctionsHelpers.CreateHttpResponseData(req, blogPosts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting blogPosts");
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }

    [Function(nameof(BlogPostsGetById))]
    public async Task<HttpResponseData> BlogPostsGetById(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "blogposts/{id}")] HttpRequestData req,
    int id)
    {
        _logger.LogInformation("---> {FunctionName} function processed a request.", nameof(BlogPostsGetById));

        try
        {
            var blogPost = await _repo.GetAsync(id);
            if (blogPost is null)
            {
                return req.CreateResponse(HttpStatusCode.NotFound);
            }

            return AzureFunctionsHelpers.CreateHttpResponseData(req, blogPost);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting blogPost");
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }


    [Function(nameof(BlogPostsCreate))]
    public async Task<HttpResponseData> BlogPostsCreate([HttpTrigger(AuthorizationLevel.Function, "post", Route = "blogposts")] HttpRequestData req)
    {
        _logger.LogInformation("---> {FunctionName} function processed a request.", nameof(BlogPostsCreate));

        try
        {
            var requestData = await new StreamReader(req.Body).ReadToEndAsync();
            var blogPostCreateDto = JsonSerializer.Deserialize<BlogPostCreateDto>(requestData, _jsonSerializerOptions);

            if (blogPostCreateDto == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

            var blogPost = new BlogPost
            {
                BlogId = blogPostCreateDto.BlogId,
                Title = blogPostCreateDto.Title,
                Slug = blogPostCreateDto.Slug,
                Description = blogPostCreateDto.Description,
                Content = blogPostCreateDto.Content,
                PublishedOnDate = blogPostCreateDto.PublishedOnDate,
                ContentType = blogPostCreateDto.ContentType,
                BlogCategories = blogPostCreateDto.Categories
            };

            await _repo.AddAsync(blogPost);

            var response = req.CreateResponse(HttpStatusCode.Created);
            await response.WriteAsJsonAsync(blogPost);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding blog post");
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
