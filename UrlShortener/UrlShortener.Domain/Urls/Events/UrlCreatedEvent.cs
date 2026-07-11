using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Urls.Events;

public sealed record UrlCreatedEvent(
    Guid UrlId,
    string ShortCode,
    string LongUrl,
    DateTimeOffset CreatedAt) : IDomainEvent;
