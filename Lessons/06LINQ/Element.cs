using System;

namespace LINQ
{
    public record Element
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }

        public int Number { get; init; }
    }
};
