using System;

namespace DictionaryWithCompositeKey
{
    public record CompositeKey<TId, TName> : IComparable
        where TId : IComparable
        where TName : IComparable
    {
        public TId Id { get; }
        public TName Name { get; }

        private readonly bool _priorityId = true;

        public int CompareTo(object? obj)
        {
            if (obj is null)
                return 1;
            if (obj is CompositeKey<TId, TName> right)
            {
                if(_priorityId)
                {
                    if (Id is null)
                    {
                        if (right.Id is null) 
                            return Name.CompareTo(right.Name);
                        return -1;
                    }

                    if (Id.CompareTo(right.Id) == 0)
                        return Name.CompareTo(right.Name);
                    return Id.CompareTo(right.Id);
                }
                if (Name is null)
                {
                    if (right.Name is null)
                        return Id.CompareTo(right.Id);
                    return -1;
                }
                if (Name.CompareTo(right.Name) == 0)
                    return Id.CompareTo(right.Id);
                return Name.CompareTo(right.Name);
            }
            throw new ArgumentException(
                $"Object must be of type CompositeKey<{typeof(TId).Name}, {typeof(TName).Name}>");
        }

        public CompositeKey(TId id, TName name)
        {
            Id = id;
            Name = name;
        }

        public CompositeKey(TId id, TName name, bool priorityId)
            : this(id, name)
            => _priorityId = priorityId;
    }
}
