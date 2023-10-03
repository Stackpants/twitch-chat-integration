using System.Net.WebSockets;
using System.Text;
using Kestrel.TCI.Application;
using Kestrel.TCI.Integration.Twitch;
using Microsoft.Extensions.Hosting;


namespace Kestrel.TCI.Host.Services;

public class TwitchBackgroundWorker : BackgroundService
{
    private readonly ITwitchService twitchService;
    private readonly IMessageHandler messageHandler;
    private ClientWebSocket? socketClient;
    private const string SocketUrl = "ws://irc-ws.chat.twitch.tv:80";


    public TwitchBackgroundWorker(ITwitchService twitchService, IMessageHandler messageHandler)
    {
        this.twitchService = twitchService ?? throw new ArgumentNullException(nameof(twitchService));
        this.messageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ConnectClient(stoppingToken);
                while (socketClient?.State == WebSocketState.Open)
                {
                    var message = await ReceiveMessage(stoppingToken);
                    await messageHandler.HandleMessage(message);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error occurred: {e.Message}");
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }


    private async Task ConnectClient(CancellationToken cancelled)
    {
        socketClient = new ClientWebSocket();
        await socketClient.ConnectAsync(new Uri(SocketUrl), cancelled);
        // twitch specific connection stuff
        await SendMessage(@"NICK justinfan987600", cancelled);
        await SendMessage(@"CAP REQ :twitch.tv/tags twitch.tv/commands", cancelled);
        await SendMessage(@"JOIN #hasanabi", cancelled);
    }


    private async Task SendMessage(string message, CancellationToken cancelled)
    {
        // only send messages if the connection is actually open.
        if (socketClient.State != WebSocketState.Open)
        {
            return;
        }

        var bytesToSend = Encoding.UTF8.GetBytes(message);
        await socketClient.SendAsync(
            new ArraySegment<byte>(bytesToSend, 0, bytesToSend.Length),
            WebSocketMessageType.Text,
            WebSocketMessageFlags.EndOfMessage,
            cancelled
        );
    }


    private async Task<string> ReceiveMessage(CancellationToken cancelled)
    {
        var builder = new StringBuilder();
        WebSocketReceiveResult result;
        byte[] buffer = new byte[1024];
        do
        {
            result = await socketClient!.ReceiveAsync(new ArraySegment<byte>(buffer), cancelled);
            builder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
        } while (!result.EndOfMessage);

        return builder.ToString();
    }
}
