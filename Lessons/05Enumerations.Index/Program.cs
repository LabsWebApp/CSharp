using System;
using static System.Console;
using System.Collections;

namespace Enumerations.Index
{
    public class UserCollection : IEnumerator, IEnumerable
    {
        private int i = 99;
        private object o = new();
        private string s = "Hi";
        
        private int _position = -1;
        private const int len = 3;
        public bool MoveNext()
        {
            if (_position < len - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset() => _position = -1;

        public object Current => _position switch
        {
            0 => i,
            1 => o,
            2 => s,
            _ => throw new IndexOutOfRangeException()
        };

        public IEnumerator GetEnumerator()
        {
            //Reset();
            return this;
        }

        public object this[int ind] => ind switch
        {
            0 => i,
            1 => o,
            2 => s,
            _ => throw new IndexOutOfRangeException()
        };

        public object this[string type] => type switch
        {
            "int" => i,
            "object" => o,
            "string" => s,
            _ => throw new IndexOutOfRangeException()
        };
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Lazy<UserCollection> obj = new Lazy<UserCollection>();

            if (DateTime.Now.Hour < 9) WriteLine(obj.Value[0]);





            UserCollection userCollection = new UserCollection();
            foreach (var item in userCollection)
            {
                WriteLine(item);
            }

            WriteLine("**********************");
            WriteLine(userCollection[2]);
            WriteLine(userCollection[0]);
            WriteLine(userCollection[1]);

            WriteLine("**********************");
            WriteLine(userCollection["object"]);
            WriteLine(userCollection["string"]);
            WriteLine(userCollection["int"]);

            ReadKey();
        }
    }
}
