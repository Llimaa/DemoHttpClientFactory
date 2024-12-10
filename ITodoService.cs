using Refit;

namespace DemoHttpClientFactory;

public interface ITodoService
{
    [Get("/todo")]
    Task<Todo[]> GetTodosGeneratedClientsAsync();
}