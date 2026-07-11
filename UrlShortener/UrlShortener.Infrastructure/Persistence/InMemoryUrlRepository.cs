using System.Collections.Concurrent;
using UrlShortener.Domain.Urls;

namespace UrlShortener.Infrastructure.Persistence;

/// <summary>
/// In-memory adapter for <see cref="IUrlRepository"/>. Placeholder until the
/// Temp solution
/// </summary>
public sealed class InMemoryUrlRepository : IUrlRepository
{
    private readonly ConcurrentDictionary<string, Url> _store = new();

    public Task<bool> AddAsync(Url url, CancellationToken cancellationToken = default)
        => Task.FromResult(_store.TryAdd(url.ShortCode.Value, url));

    public Task<Url?> GetByShortCodeAsync(ShortCode shortCode, CancellationToken cancellationToken = default)
    {
        _store.TryGetValue(shortCode.Value, out var url);
        return Task.FromResult(url);
    }

    public Task<bool> ExistsAsync(ShortCode shortCode, CancellationToken cancellationToken = default)
        => Task.FromResult(_store.ContainsKey(shortCode.Value));
}
