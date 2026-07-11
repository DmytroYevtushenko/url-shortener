namespace UrlShortener.Domain.Common;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
    // TODO: temp, not needed now. Want to play with domain events after
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected AggregateRoot(TId id) : base(id) { }

    protected AggregateRoot() { }

    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();
}
