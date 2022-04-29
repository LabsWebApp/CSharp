namespace DictionaryWithCompositeKey;

public record class CompositeKeyRecord<TId, T>
{
    public CompositeKeyRecord(TId? Id, T? Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public TId? Id { get; init; }
    public T? Name { get; init; }
}