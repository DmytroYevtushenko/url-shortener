using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Urls;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.ShortCodes;

namespace UrlShortener.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Singleton: the in-memory store must persist data across requests.
        // When EF Core - change to Scoped.
        services.AddSingleton<IUrlRepository, InMemoryUrlRepository>();
        services.AddSingleton<IShortCodeGenerator, Base62ShortCodeGenerator>();

        return services;
    }
}
