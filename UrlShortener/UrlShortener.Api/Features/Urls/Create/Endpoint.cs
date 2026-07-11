using FastEndpoints;

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
        var response = await handler.HandleAsync(request, cancellationToken);
        await Send.OkAsync(response, cancellationToken);
    }
}
