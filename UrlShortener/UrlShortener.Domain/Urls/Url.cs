using UrlShortener.Domain.Common;
using UrlShortener.Domain.Urls.Events;

namespace UrlShortener.Domain.Urls;

public sealed class Url : AggregateRoot<Guid>
{
    public ShortCode ShortCode { get; private set; }
    public string LongUrl { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    private Url(Guid id, ShortCode shortCode, string longUrl, DateTimeOffset createdAt) : base(id)
    {
        ShortCode = shortCode;
        LongUrl = longUrl;
        CreatedAt = createdAt;
    }

    public static Url Create(ShortCode shortCode, string longUrl, DateTimeOffset createdAt)
    {
        if (string.IsNullOrWhiteSpace(longUrl))
            throw new ArgumentException("Long URL cannot be empty.", nameof(longUrl));

        var url = new Url(Guid.CreateVersion7(), shortCode, longUrl, createdAt);
        url.Raise(new UrlCreatedEvent(url.Id, shortCode.Value, longUrl, createdAt));
        return url;
    }
}
