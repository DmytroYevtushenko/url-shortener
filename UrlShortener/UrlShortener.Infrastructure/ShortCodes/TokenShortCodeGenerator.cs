using UrlShortener.Domain.Urls;

namespace UrlShortener.Infrastructure.ShortCodes;

public sealed class TokenShortCodeGenerator(TokenProvider tokenProvider) : IShortCodeGenerator
{
    public ShortCode Generate()
    {
        var token = tokenProvider.GetToken();
        var code = token.EncodeToBase62();
        return ShortCode.Create(code);
    }
}
