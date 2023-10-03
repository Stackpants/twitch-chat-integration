namespace Kestrel.TCI.Application;

public interface IMessageHandler
{
    public Task HandleMessage(string message);
}
