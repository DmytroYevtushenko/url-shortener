namespace UrlShortener.Domain.Common;

public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; } = default!;

    protected Entity(TId id) => Id = id;

    // Parameterless ctor kept for ORM materialization (EF Core) later on.
    protected Entity() { }

    public override bool Equals(object? obj) =>
        obj is Entity<TId> other && GetType() == other.GetType() && Id.Equals(other.Id);

    public override int GetHashCode() => Id.GetHashCode();
}
