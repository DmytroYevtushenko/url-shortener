using UrlShortener.Domain.Urls;

namespace UrlShortener.Infrastructure.ShortCodes;

public static class Base62EncodingExtensions
{
    public static string EncodeToBase62(this long number)
    {
        var alphabet = ShortCode.Alphabet;

        if (number == 0)
            return alphabet[0].ToString();

        var result = new Stack<char>();
        while (number > 0)
        {
            result.Push(alphabet[(int)(number % alphabet.Length)]);
            number /= alphabet.Length;
        }

        return new string(result.ToArray());
    }
}
