using Kestrel.TCI.Integration.Twitch;
using Microsoft.Extensions.DependencyInjection;


namespace Kestrel.TCI.Host.Services;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITwitchService, TwitchService>();
        return services;
    }
}
