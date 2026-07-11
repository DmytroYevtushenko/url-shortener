using UrlShortener.Domain.Common;
using UrlShortener.Domain.Urls;

namespace UrlShortener.Api.Features.Urls.Create;

public sealed class Handler(
    IShortCodeGenerator shortCodeGenerator,
    IUrlRepository urlRepository,
    TimeProvider timeProvider)
{
    public async Task<Result<Response>> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var shortCode = shortCodeGenerator.Generate();

        var url = Url.Create(shortCode, request.LongUrl, timeProvider.GetUtcNow());

        var added = await urlRepository.AddAsync(url, cancellationToken);
        if (!added)
            return UrlErrors.ShortCodeConflict;

        return new Response
        {
            ShortCode = url.ShortCode.Value,
            ShortUrl = $"/{url.ShortCode.Value}",
            LongUrl = url.LongUrl
        };
    }
}
