namespace UrlShortener.Domain.Urls;

public interface IUrlRepository
{
    Task<bool> AddAsync(Url url, CancellationToken cancellationToken = default);

    Task<Url?> GetByShortCodeAsync(ShortCode shortCode, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(ShortCode shortCode, CancellationToken cancellationToken = default);
}
