namespace Kestrel.TCI.Core.TwitchCommands;

public record Pong(string Message) : TwitchCommand("PONG");
