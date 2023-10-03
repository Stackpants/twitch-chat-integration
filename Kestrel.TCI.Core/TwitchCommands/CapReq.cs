namespace Kestrel.TCI.Core.TwitchCommands;

public record CapReq(string Capabilities = "twitch.tv/tags twitch.tv/commands") : TwitchCommand("CAP REQ");
