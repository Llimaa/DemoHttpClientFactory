using Refit;

namespace DemoHttpClientFactory;

public static class BasicHttpClient 
{
    public static IServiceCollection AddBasicHttpClient(this IServiceCollection services) 
    {
        services.AddScoped<TodoService>();
        services.AddHttpClient();
        return services;
    }

    public static IServiceCollection AddNamedClients(this IServiceCollection services) 
    {
        var httpClientName = "TodoHttpClient";
        services.AddHttpClient(
            httpClientName,
            client => client.BaseAddress = new Uri("http://localhost:5253")
        );

        return services;
    }

    public static IServiceCollection AddTypedClients(this IServiceCollection services) 
    {
        services.AddHttpClient<TodoService>(
            client => client.BaseAddress = new Uri("http://localhost:5253")
        );

        return services;
    }

    public static IServiceCollection AddGeneratedClients(this IServiceCollection services) 
    {
        services.AddRefitClient<ITodoService>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5253/");
            });
        return services;
    }
}