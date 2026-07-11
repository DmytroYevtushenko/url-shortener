using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Urls;

public static class UrlErrors
{
    public static readonly Error ShortCodeConflict = Error.Conflict(
        "Url.ShortCodeConflict",
        "A URL with this short code already exists.");

    public static Error NotFound(string shortCode) => Error.NotFound(
        "Url.NotFound",
        $"No URL was found for short code '{shortCode}'.");
}
