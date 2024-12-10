using System.Text.Json;

namespace DemoHttpClientFactory;

public sealed class TodoService(IHttpClientFactory httpClientFactory, HttpClient httpClient, ILogger<TodoService> logger)
{
    public async Task<Todo[]> GetTodosWithBasicHttpClientAsync()
    {
        using HttpClient client = httpClientFactory.CreateClient();
        
        try
        {
            var todos = await client.GetFromJsonAsync<Todo[]>(
                $"http://localhost:5253/todo",
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
            );

            return todos ?? [];
        }
        catch (Exception ex)
        {
            logger.LogError("Error getting todos. Details: {Error}", ex);
        }

        return [];
    }

    public async Task<Todo[]> GetTodosNamedClientsAsync()
    {
        var httpClientName = "TodoHttpClient";
        using HttpClient client = httpClientFactory.CreateClient(httpClientName);

        try
        {
            var todos = await client.GetFromJsonAsync<Todo[]>(
                $"todo",
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
            );

            return todos ?? [];
        }
        catch (Exception ex)
        {
            logger.LogError("Error getting todos. Details: {Error}", ex);
        }

        return [];
    }

    public async Task<Todo[]> GetTodosTypedClientsAsync()
    {
        try
        {
            var todos = await httpClient.GetFromJsonAsync<Todo[]>(
                $"todo",
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
            );

            return todos ?? [];
        }
        catch (Exception ex)
        {
            logger.LogError("Error getting todos. Details: {Error}", ex);
        }

        return [];
    }
}
