namespace UrlShortener.Api.Features.Urls.Create;

public sealed class Response
{
    public required string ShortCode { get; init; }
    public required string ShortUrl { get; init; }
    public required string LongUrl { get; init; }
}
