namespace MassTransit.InMemory2;

public class PingConsumer(ILogger<PingConsumer> logger) : IConsumer<Ping>
{
    public Task Consume(ConsumeContext<Ping> context)
    {
        var button = context.Message.Button;
        logger.LogInformation("Button pressed {Button}", button);
        return Task.CompletedTask;
    }
}