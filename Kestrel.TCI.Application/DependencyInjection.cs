using Microsoft.Extensions.DependencyInjection;


namespace Kestrel.TCI.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMessageHandler, FileWriteMessageHandler>();
        return services;
    }
}
