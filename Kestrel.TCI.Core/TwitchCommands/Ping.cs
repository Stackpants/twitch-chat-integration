namespace Kestrel.TCI.Core.TwitchCommands;

public record Ping(string Message) : TwitchCommand("PING");
