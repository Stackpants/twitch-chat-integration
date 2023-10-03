namespace Kestrel.TCI.Core.TwitchCommands;

public record Join(string Channel) : TwitchCommand("JOIN");
