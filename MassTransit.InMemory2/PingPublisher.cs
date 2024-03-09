namespace MassTransit.InMemory2;

public class PingPublisher : BackgroundService
{
    private readonly ILogger<PingPublisher> _logger;

    public PingPublisher(ILogger<PingPublisher> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Yield();

            var keyPressed = Console.ReadKey();
            if (keyPressed.Key != ConsoleKey.Escape)
            {
                _logger.LogInformation("Pressed {Button}", keyPressed.Key.ToString());
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}