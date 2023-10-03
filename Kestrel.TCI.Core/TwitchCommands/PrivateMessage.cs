namespace Kestrel.TCI.Core.TwitchCommands;

public record PrivateMessage(string Message) : TwitchCommand("PRIVMSG");
