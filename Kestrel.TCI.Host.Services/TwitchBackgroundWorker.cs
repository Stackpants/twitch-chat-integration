using Microsoft.Extensions.Hosting;


namespace Kestrel.TCI.Host.Services;

public class TwitchBackgroundWorker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Please implement Twitch Service ...");
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}
