namespace MassTransit.InMemory2;

public class PingPublisher(IBus bus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Yield();

            var keyPressed = Console.ReadKey();
            if (keyPressed.Key != ConsoleKey.Escape)
            {
                await bus.Publish(new Ping(keyPressed.Key.ToString()), stoppingToken);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}