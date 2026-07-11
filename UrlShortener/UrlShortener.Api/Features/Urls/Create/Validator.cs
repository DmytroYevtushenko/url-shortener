using FastEndpoints;
using FluentValidation;

namespace UrlShortener.Api.Features.Urls.Create;

public sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.LongUrl)
            .NotEmpty().WithMessage("Long URL is required.")
            .Must(BeAValidHttpUrl).WithMessage("Long URL must be a valid absolute http(s) URL.");
    }

    private static bool BeAValidHttpUrl(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
        (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
}
