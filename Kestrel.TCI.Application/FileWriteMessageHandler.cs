namespace Kestrel.TCI.Application;

public class FileWriteMessageHandler : IMessageHandler
{
    private readonly SemaphoreSlim writeLock;
    private readonly string folderPath;

    public FileWriteMessageHandler()
    {
        writeLock = new SemaphoreSlim(1, 1);
        folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kestrel");
        CreateDirectoryIfNotExist();
    }


    public async Task HandleMessage(string message)
    {
        await writeLock.WaitAsync();
        try
        {
            await using var writer = new StreamWriter(Path.Combine(folderPath, "chat-dump.txt"), true);
            writer.AutoFlush = true;
            await writer.WriteLineAsync(message);
        }

        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        writeLock.Release();
    }


    private void CreateDirectoryIfNotExist()
    {
        try
        {
            Directory.CreateDirectory(folderPath);
        }

        catch (Exception e)
        {
            Console.WriteLine($"Cant create folders {e.Message}");
            Environment.Exit(0);
        }
    }
}
