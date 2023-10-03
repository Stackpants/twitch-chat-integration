namespace Kestrel.TCI.Core.TwitchCommands;

public record Part(string Channel) : TwitchCommand("PART");
