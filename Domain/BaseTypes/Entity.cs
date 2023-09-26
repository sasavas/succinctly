namespace Domain.BaseTypes;

public class Entity<TId>
{
    public TId Id { get; private protected init; } = default!;
}