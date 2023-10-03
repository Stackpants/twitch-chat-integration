namespace Kestrel.TCI.Core.TwitchCommands;

public record Notice(string Content) : TwitchCommand("NOTICE");
