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

    public Task AddAsync(Url url, CancellationToken cancellationToken = default)
    {
        return !_store.TryAdd(url.ShortCode.Value, url)
            ? throw new InvalidOperationException($"Short code '{url.ShortCode.Value}' already exists.")
            : Task.CompletedTask;
    }

    public Task<Url?> GetByShortCodeAsync(ShortCode shortCode, CancellationToken cancellationToken = default)
    {
        _store.TryGetValue(shortCode.Value, out var url);
        return Task.FromResult(url);
    }

    public Task<bool> ExistsAsync(ShortCode shortCode, CancellationToken cancellationToken = default)
        => Task.FromResult(_store.ContainsKey(shortCode.Value));
}
