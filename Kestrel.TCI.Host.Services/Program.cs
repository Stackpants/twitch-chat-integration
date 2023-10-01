using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Kestrel.TCI.Host.Services;

public class Program
{
    public static void Main(string[] arguments)
    {
        Create(arguments)
            .Build()
            .Run();
    }


    public static IHostBuilder Create(string[] arguments)
    {
        var builder = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .ConfigureServices(ConfigureConsole);
        return builder;
    }


    public static void ConfigureConsole(HostBuilderContext context, IServiceCollection services)
    {
        // background services
        services.AddHostedService<TwitchBackgroundWorker>();
    }
}
