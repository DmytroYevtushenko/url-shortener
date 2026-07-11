namespace UrlShortener.Infrastructure.ShortCodes;

public sealed class TokenProvider
{
    private readonly object _tokenLock = new();

    private long _token;
    private TokenRange? _tokenRange;

    public void AssignRange(long start, long end) => AssignRange(new TokenRange(start, end));

    public void AssignRange(TokenRange tokenRange)
    {
        lock (_tokenLock)
        {
            _tokenRange = tokenRange;
            _token = tokenRange.Start;
        }
    }

    public long GetToken()
    {
        lock (_tokenLock)
        {
            if (_tokenRange is null)
                throw new InvalidOperationException("No token range has been assigned.");

            if (_token > _tokenRange.End)
                throw new InvalidOperationException(
                    "Token range exhausted. (Next step: request a fresh range from the TokenRange service.)");

            return _token++;
        }
    }
}
