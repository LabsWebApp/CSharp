using System;
using static System.Console;
using System.Collections;

namespace Enumerations.Index
{
    public class UserCollection //: IEnumerable, IEnumerator
    {
        private readonly int i = 99;
        private readonly object o = new();
        private readonly string s = "Hi";
        
        private int _position = -1;
        private const int Len = 3;
        public bool MoveNext()
        {
            if (_position < Len - 1)
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
            _ => throw new InvalidOperationException()
        };

        public UserCollection GetEnumerator()
        {
            Reset();
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
            "int" or "Int32" or "System.Int32" => i,
            "object" or "Object" or "System.Object" => o,
            "string" or "String" or "System.String" => s,
            _ => throw new IndexOutOfRangeException()
        };
    }

    class Program
    {
        
        static void Main(string[] args)
        {

            var userCollection = new UserCollection();
            foreach (var item in userCollection)
            {
                WriteLine(item);
            }

            WriteLine("**********************");
            WriteLine(userCollection[2]);
            WriteLine(userCollection[0]);
            WriteLine(userCollection[1]);
            WriteLine("**********************");
            WriteLine(userCollection["Object"]);
            WriteLine(userCollection["string"]);
            WriteLine(userCollection["System.Int32"]);

            ReadKey();
        }
    }
}
