using System.Net.WebSockets;


namespace Kestrel.TCI.Integration.Twitch;

public class WebsocketChatClient : IChatClient
{
    private readonly ClientWebSocket socketConnection;
    
    public WebsocketChatClient()
    {
        this.socketConnection = new ClientWebSocket();
    }


    public async Task Connect(Uri url, CancellationToken stoppingToken)
    {
        // socketConnection.ReceiveAsync()
        
        await socketConnection.ConnectAsync(url, stoppingToken);
        
    }
}
