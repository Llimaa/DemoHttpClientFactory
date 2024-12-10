namespace DemoHttpClientFactory;

public record Todo
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid GuidTest { get; set; }
}
