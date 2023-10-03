namespace Kestrel.TCI.Core.TwitchCommands;

public record Nick(string Nickname) : TwitchCommand("NICK");
