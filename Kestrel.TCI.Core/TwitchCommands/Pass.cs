namespace Kestrel.TCI.Core.TwitchCommands;

public record Pass(string Password) : TwitchCommand("PASS");
