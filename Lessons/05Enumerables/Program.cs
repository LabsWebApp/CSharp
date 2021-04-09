using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Enumerations
{
    public record Item
    {
        public int Id { get; init; }
        public string Name { get; init; }

        //public override string ToString()
        //    => $"ID = {Id}, Name = {Name}.";
    }

    class Program
    {
        public class UserCollection : IEnumerable, IEnumerator
        {
            private int _position = -1;

            private readonly Item[] _items =
            {
                new (){Name = "A", Id = 0},
                new (){Name = "A", Id = 1},
                new (){Name = "B", Id = 2},
                new (){Name = "C", Id = 3}
            };

            public IEnumerator GetEnumerator()
            {
                Reset();
                return this;
            }
            public bool MoveNext()
            {
                if (_position < _items.LongLength - 1)
                {
                    _position++;
                    return true;
                }
                return false;
            }

            public void Reset() => _position = -1;

            public object Current => _items[_position];

            public Item this[int ind]
            {
                get
                {
                    foreach (var item in _items)
                    {
                        if (item.Id == ind)
                            return item;
                    }

                    return null;
                }
            }

            public IEnumerable<Item> this[string name]
            {
                get
                {
                    foreach (var item in _items)
                    {
                        if (item.Name == name)
                            yield return item;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            UserCollection a = new();

            foreach (var item in a) WriteLine(item);

            WriteLine("*****+*****");
            
            foreach (var item in a["A"]) 
                WriteLine(item);

            var witha = a["a"];

            foreach (var item in witha)
                WriteLine(item);
           
            WriteLine(witha);

            WriteLine("*****+*****");
            WriteLine(a[3]);
            ReadKey();

        }
    }

}
