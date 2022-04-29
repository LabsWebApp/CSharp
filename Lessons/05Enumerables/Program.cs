using System.Collections;
using System.Numerics;
using static System.Console;

namespace Enumerations.Index;


public record class Item(string Name, int Id);

public class UserCollection
{
    private int _position = -1;

    private readonly Item[] _items =
    {
        new ("Petya", 13),
        new ("Petya", 12),
        new ("B", 11),
        new ("C", 10)
    };

    public UserCollection GetEnumerator()
    {
        _position = -1;
        return this;
    }

    public bool MoveNext()
    {
        if (_position < _items.Length - 1)
        {
            _position++;
            return true;
        }
        return false;
    }

    public Item Current => _items[_position];

    internal string this[int id]
    {
        get
        {
            foreach (var item in _items)
                if (item.Id == id) return item.Name;

            throw new IndexOutOfRangeException();
        }
        set
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Id != id) continue;

                _items[i] = _items[i] with { Name = value };
                return;
            }
            throw new IndexOutOfRangeException();
        }
    }

    public IEnumerable<Item> this[string name]
    {
        get
        {
            foreach (var item in _items)
            {
                if (item.Name.ToLower().Trim() == name.ToLower().Trim()) 
                    yield return item;
            }
        }
    }
}

//public class UserCollection //: IEnumerable, IEnumerator
//{
//    private int _position = -1;

//    private readonly Item[] _items =
//    {
//        new ("Petya", 3),
//        new ("Petya", 2),
//        new ("B", 1),
//        new ("C", 0)
//    };

//    public UserCollection GetEnumerator()
//    {
//        _position = -1;
//        return this;
//    }
//    public bool MoveNext()
//    {
//        if (_position < _items.LongLength - 1)
//        {
//            _position++;
//            return true;
//        }
//        return false;
//    }

//    public object Current => _items[_position];

//    public Item this[int ind] //=> _items[ind];
//    {
//        get
//        {
//            foreach (var item in _items)
//                if (item.Id == ind) return item;

//            throw new ArgumentOutOfRangeException();
//        }
//    }

//    public IEnumerable this[string name]
//    {
//        get
//        {
//            foreach (var item in _items)
//            {
//                if (item.Name == name)
//                    yield return item;
//            }
//        }
//    }
//}
class Program
{
    static void Main()
    {
        EndlessCollection collection = new();

        //foreach (var item in collection)
        //{
        //    Console.
        //}
        WriteLine(collection[ushort.MaxValue]);

        ReadKey();


        UserCollection a = new();

        for (int i = 10; i <= 13; i++)
        {
            WriteLine(a[i]);
        }

        WriteLine("*****+*****");

        var masha = a["Masha"];
        WriteLine(masha);
        foreach (var item in masha)
            WriteLine(item);
        WriteLine("*****+*****");

        a[11] = "Masha";
        foreach (var item in masha)
            WriteLine(item);
        WriteLine("*****+*****");

        for (int i = 10; i <= 13; i++)
        {
            WriteLine(a[i]);
        }
        WriteLine("*****+*****");

        foreach (var item in a["Petya"]) 
            WriteLine(item);
        WriteLine("*****+*****");

        var withPetya = a["Petya"];

        foreach (var item in withPetya)
            WriteLine(item);
           
        WriteLine(withPetya.GetType().FullName);
        WriteLine(withPetya.GetType().Name);

        WriteLine("*****+*****");

        withPetya = a["k"];

        foreach (var item in withPetya)
            WriteLine(item);
        WriteLine(withPetya.GetType().FullName);
        WriteLine(withPetya.GetType().Name);

        ReadKey();

        EndlessCollection col = new();
        WriteLine(col[1000]);

    }
}

class EndlessCollection
{
    private BigInteger _first = BigInteger.Zero;

    private IEnumerable<BigInteger> GetEnumerable()
    {
        while (true) yield return _first++;
    }

    public IEnumerator<BigInteger> GetEnumerator() => GetEnumerable().GetEnumerator();

    public int this[ushort index]
    {
        get
        {
            foreach (var b in this)
                if (b == index) return (int)b;
            return 0;
        }
    }

    public IEnumerable<BigInteger> this[(BigInteger From, BigInteger To) range]
    {
        get
        {
            for (var b = range.From; b <= range.To; b++) yield return b;
        }
    }
}