namespace Kestrel.TCI.Core.TwitchCommands;

// find more types at https://dev.twitch.tv/docs/irc/
// Currently have not implemented any of the Twitch-specific IRC messages.
// At the time of writing these included:
// CLEARCHAT
// CLEARMSG
// GLOBALUSERSTATE
// HOSTTARGET
// NOTICE
// RECONNECT
// ROOMSTATE
// USERNOTICE
// USERSTATE
// WHISPER
public record TwitchCommand(string Name);
