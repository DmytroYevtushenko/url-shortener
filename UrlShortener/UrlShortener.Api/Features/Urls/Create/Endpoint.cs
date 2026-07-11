using FastEndpoints;
using UrlShortener.Api.Common;

namespace UrlShortener.Api.Features.Urls.Create;

public sealed class Endpoint(Handler handler) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/urls");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var result = await handler.HandleAsync(request, cancellationToken);

        var httpResult = result.IsSuccess
            ? Results.Created(result.Value.ShortUrl, result.Value)
            : Results.Json(
                new ApiError(result.Error.Code, result.Error.Description),
                statusCode: result.Error.ToHttpStatusCode());

        await Send.ResultAsync(httpResult);
    }
}
