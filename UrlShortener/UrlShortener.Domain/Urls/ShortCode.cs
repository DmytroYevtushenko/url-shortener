namespace UrlShortener.Domain.Urls;

public sealed record ShortCode
{
    public const int MaxLength = 7;
    public const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public string Value { get; }

    private ShortCode(string value) => Value = value;

    public static ShortCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Short code cannot be empty.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"Short code must be at most {MaxLength} characters.", nameof(value));

        foreach (var c in value)
        {
            if (!Alphabet.Contains(c))
                throw new ArgumentException($"Short code contains invalid character '{c}'.", nameof(value));
        }

        return new ShortCode(value);
    }

    public override string ToString() => Value;
}
