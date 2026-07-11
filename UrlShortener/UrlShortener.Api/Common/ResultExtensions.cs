using UrlShortener.Domain.Common;

namespace UrlShortener.Api.Common;

public static class ResultExtensions
{
    public static int ToHttpStatusCode(this Error error) => error.Type switch
    {
        ErrorType.Validation => StatusCodes.Status400BadRequest,
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        ErrorType.Conflict => StatusCodes.Status409Conflict,
        _ => StatusCodes.Status500InternalServerError
    };
}
