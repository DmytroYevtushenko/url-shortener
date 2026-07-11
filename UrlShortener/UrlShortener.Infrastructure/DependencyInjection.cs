using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Urls;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.ShortCodes;

namespace UrlShortener.Infrastructure;

/// <summary>
/// Composition root for the Infrastructure layer — binds domain ports to their concrete adapters.
/// Both the Api and the Redirect service call this.
/// </summary>
public static class DependencyInjection
{
    // 62^7 - 1 — the largest token that still base62-encodes to <= ShortCode.MaxLength (7) chars.
    private const long MaxToken = 3_521_614_606_207;

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Singleton: the in-memory store must persist data across requests.
        // When EF Core lands, this becomes Scoped.
        services.AddSingleton<IUrlRepository, InMemoryUrlRepository>();

        var tokenProvider = new TokenProvider();
        tokenProvider.AssignRange(1, MaxToken); // dev seed; real ranges will come from the TokenRange service (PLAN.md)
        services.AddSingleton(tokenProvider);
        services.AddSingleton<IShortCodeGenerator, TokenShortCodeGenerator>();

        // System clock as an injectable, test-swappable dependency (replaces direct DateTimeOffset.UtcNow).
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
