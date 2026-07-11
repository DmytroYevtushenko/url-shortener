using UrlShortener.Domain.Urls;

namespace UrlShortener.Api.Features.Urls.Create;

public sealed class Handler(IShortCodeGenerator shortCodeGenerator, IUrlRepository urlRepository)
{
    public async Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var shortCode = shortCodeGenerator.Generate();

        var url = Url.Create(shortCode, request.LongUrl, DateTimeOffset.UtcNow);

        await urlRepository.AddAsync(url, cancellationToken);

        return new Response
        {
            ShortCode = url.ShortCode.Value,
            ShortUrl = $"/{url.ShortCode.Value}",
            LongUrl = url.LongUrl
        };
    }
}
