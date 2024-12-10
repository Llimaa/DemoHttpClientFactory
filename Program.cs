using DemoHttpClientFactory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBasicHttpClient()
    .AddNamedClients()
    .AddTypedClients()
    .AddGeneratedClients();

var app = builder.Build();

app.MapGet("/basic", (TodoService todoService) => todoService.GetTodosWithBasicHttpClientAsync());

app.MapGet("/named", (TodoService todoService) => todoService.GetTodosNamedClientsAsync());

app.MapGet("/typed", (TodoService todoService) => todoService.GetTodosTypedClientsAsync());

app.MapGet("/generated", (ITodoService todoService) => todoService.GetTodosGeneratedClientsAsync());

app.Run();
