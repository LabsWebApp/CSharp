using static System.Console;
using System.Collections.Generic;

namespace DictionaryWithCompositeKey
{
    class Program
    {
        //public class DictionaryWithReaderWriterLock<TKey, TValue>
        //{
        //    private readonly ReaderWriterLockSlim _dictionaryLock = new (); 
        //    private readonly Dictionary<TKey, TValue> _dictionary;

        //    public DictionaryWithReaderWriterLock()
        //    {
        //        _dictionary = new Dictionary<TKey, TValue>();
        //    }

        //    public TValue this[TKey key]
        //    {
        //        get
        //        {
        //            _dictionaryLock.EnterReadLock();
        //            try
        //            {
        //                return _dictionary[key];
        //            } 
        //            finally { _dictionaryLock.ExitReadLock(); }
        //        }
        //        set
        //        {
        //            _dictionaryLock.EnterWriteLock();
        //            try
        //            {
        //                _dictionary[key] = value;
        //            } 
        //            finally { _dictionaryLock.ExitWriteLock(); }
        //        }
        //    }

        //    public void Add(TKey key, TValue value)
        //    {
        //        _dictionaryLock.EnterWriteLock();
        //        try
        //        {
        //            _dictionary.Add(key, value);
        //        } 
        //        finally { _dictionaryLock.ExitWriteLock(); }
        //    }
        //}


        static void Main(string[] args)
        {
            Dictionary<int[], object> dictionary =
                new Dictionary<int[], object>();

            int[] i1 = { 1 }, i2 = { 1 };

            dictionary.Add(i1, string.Empty);
            dictionary.Add(i2, string.Empty);

            WriteLine(dictionary.Count);
           // dictionary.Add(i2, string.Empty);






            //CompositeKey<int, string> isKey = new CompositeKey<int, string>(1, null);
            //CompositeKey<int, int> iiKey = new CompositeKey<int, int>(1, 0);
            //WriteLine(isKey.CompareTo(iiKey));

            ReadKey();
        }
    }
}
