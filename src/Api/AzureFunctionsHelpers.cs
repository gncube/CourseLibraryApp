using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Text.Json;

namespace Api;

public static class AzureFunctionsHelpers
{
    public static HttpResponseData CreateHttpResponseData<T>(HttpRequestData req, IEnumerable<T> items)
    {
        var itemArrary = items.ToArray();
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        var itemsJson = JsonSerializer.Serialize(items);
        response.WriteString(itemsJson);

        return response;
    }

    public static HttpResponseData CreateHttpResponseData<T>(HttpRequestData req, T item)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        var itemJson = JsonSerializer.Serialize(item);
        response.WriteString(itemJson);

        return response;
    }
}