using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using static System.Console;

namespace ConsoleAppArrayForDel
{
    class UserCollection : IEnumerator<int>
    {
        private int[] ints = { 1, 2, 3 };

        private int position = -1;

        public bool MoveNext()
        {
            if (position < ints.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset() => position = -1;
        public object Current => ints[position];

        int IEnumerator<int>.Current => ints[position];

      //  public object Current => ints[position];
        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        public void Dispose()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UserCollection a = new UserCollection();
            
            foreach (var v in a)
            {
                WriteLine(v);
                break;
            }

            WriteLine("**************************");

            foreach (var v in a)
            {
                WriteLine(v);
            }
        }
    }
}