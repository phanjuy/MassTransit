namespace MassTransit.InMemory;

public record CurrentTime
{
    public string Value { get; init; } = string.Empty;
}