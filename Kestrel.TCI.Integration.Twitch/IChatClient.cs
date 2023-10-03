namespace Kestrel.TCI.Integration.Twitch;

public interface IChatClient
{
    public Task Connect(Uri url, CancellationToken stoppingToken);
}
