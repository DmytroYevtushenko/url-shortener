namespace UrlShortener.Api.Features.Urls.Create;

public sealed class Request
{
    public string LongUrl { get; init; } = string.Empty;
}
