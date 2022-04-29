using System;
using static System.Console;
using System.Collections.Generic;
using System.Threading;

namespace DictionaryWithCompositeKey;

class Program
{
    private class DictionaryWithReaderWriterLock<TKey, TKeyId, TKeyName, TValue>
        where TKey : CompositeKeyRecord<TKeyId, TKeyName>
    {
        private readonly ReaderWriterLockSlim _dictionaryLock = new();
        private readonly Dictionary<TKey, TValue> _dictionary = new();

        public TValue this[TKey key]
        {
            get
            {
                _dictionaryLock.EnterReadLock();
                try
                {
                    return _dictionary[key];
                }
                finally { _dictionaryLock.ExitReadLock(); }
            }
            set
            {
                _dictionaryLock.EnterWriteLock();
                try
                {
                    _dictionary[key] = value;
                }
                finally { _dictionaryLock.ExitWriteLock(); }
            }
        }

        public void Add(TKey key, TValue value)
        {
            _dictionaryLock.EnterWriteLock();
            try
            {
                _dictionary.Add(key, value);
            }
            finally { _dictionaryLock.ExitWriteLock(); }
        }

        public void Add(KeyValuePair<TKey, TValue> pair)
        {
            _dictionaryLock.EnterWriteLock();
            try
            {
                _dictionary.Add(pair.Key, pair.Value);
            }
            finally { _dictionaryLock.ExitWriteLock(); }
        }
    }

    static void Main()
    {
        List<int> list = new()
        {
            9,
            1,
            2,
            9,
            -4,
            7,
            0
        };

        foreach (var item in list)
        {
            WriteLine(item);
        }

        //WriteLine("**********");
        //list.Sort();
        //foreach (var item in list)
        //{
        //    WriteLine(item);
        //}


        WriteLine("**********");
        list.Sort(new EvenSort());
        foreach (var item in list)
        {
            WriteLine(item);
        }


        //ReadKey();

        //var dictionary =
        //    new Dictionary<CompositeKeyRecord<int, int>, string?>(2)
        //    {
        //        //{ new CompositeKeyRecord<int, int>(1, 1), "1" },
        //        { new CompositeKeyRecord<int, int>(1, 1), "2" }
        //    };


        ////WriteLine(dictionary.Count);
        //dictionary.TryGetValue(
        //    new(1, 1),
        //    out string? value);

        //WriteLine(value ?? "not found");

        ReadKey();
    }
}

internal class EvenSort : IComparer<int>
{
    public int Compare(int x, int y) => x == y ? 0 : x % 2 == 0 ? 1 : -1;
}
