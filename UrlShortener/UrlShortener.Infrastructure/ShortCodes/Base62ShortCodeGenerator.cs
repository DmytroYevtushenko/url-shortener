using System.Security.Cryptography;
using UrlShortener.Domain.Urls;

namespace UrlShortener.Infrastructure.ShortCodes;

/// <summary>
/// Random base-62 adapter for <see cref="IShortCodeGenerator"/>.
/// Temp solution.
/// </summary>
public sealed class Base62ShortCodeGenerator : IShortCodeGenerator
{
    public ShortCode Generate()
    {
        var chars = new char[ShortCode.Length];
        for (var i = 0; i < chars.Length; i++)
            chars[i] = ShortCode.Alphabet[RandomNumberGenerator.GetInt32(ShortCode.Alphabet.Length)];

        return ShortCode.Create(new string(chars));
    }
}
