namespace UrlShortener.Domain.Urls;

public sealed record ShortCode
{
    public const int Length = 7;
    public const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public string Value { get; }

    private ShortCode(string value) => Value = value;

    public static ShortCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Short code cannot be empty.", nameof(value));

        if (value.Length != Length)
            throw new ArgumentException($"Short code must be exactly {Length} characters.", nameof(value));

        foreach (var c in value.Where(c => !Alphabet.Contains(c)))
        {
            throw new ArgumentException($"Short code contains invalid character '{c}'.", nameof(value));
        }

        return new ShortCode(value);
    }

    public override string ToString() => Value;
}
