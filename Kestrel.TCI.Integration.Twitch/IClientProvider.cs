namespace Kestrel.TCI.Integration.Twitch;

public interface IClientProvider
{
    public IChatClient CreateWebSocketClient(Uri endpoint);
}
