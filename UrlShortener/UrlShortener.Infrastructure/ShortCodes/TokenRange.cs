namespace UrlShortener.Infrastructure.ShortCodes;

public sealed record TokenRange
{
    public TokenRange(long start, long end)
    {
        if (end < start)
            throw new ArgumentException("End must be greater than or equal to start.", nameof(end));

        Start = start;
        End = end;
    }

    public long Start { get; }
    public long End { get; }
}
