using System;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using UseGC;
using static System.Console;

namespace Variables
{
    enum EnumComparer : short
    {
        Less = -1,
        Equal = 0,
        More = 1
    }

    class A 
    {
        public int i = 1;

       // public int CompareTo(object obj) => 0;
    }


    class Program
    {

        static void f(int i)
        {
            i = 9;
            Console.WriteLine($"i = {i}");
        }

        static void f(System.String i)
        {
            i = "9";
            Console.WriteLine($"i = {i}");
        }
        static void f(A a)
        {
            a.i = 9;
            Console.WriteLine($"i = {a.i}");
        }

        static EnumComparer comparer(float l, float r)
            => (l - r) switch
            {
                < 0 => EnumComparer.Less,
                > 0 => EnumComparer.More,
                _ => EnumComparer.Equal
            };

        static void Main(string[] args)
        {
            WriteLine(DateTime.Now.AddDays(90));
            var dva = Math.Sqrt(2) * Math.Sqrt(2);
            WriteLine(dva);
            ReadKey();
            //int i = 
            //int i = Int32.MaxValue;
            //int j = checked(i + 1);

            //WriteLine(j);
            //object o1 = new(), o2 = new();
            //o1 = o1 * o2;
            //var tuple = (5, 10);
            //WriteLine(tuple.GetType());


            //int i = 5, j = i;

            //j = 10;

            //WriteLine(i);

            //A a = new();
            //a.i = 88;
            //A a1 = a;
            //a1.i = 99;
            //WriteLine(a.i);

            // string s = "";
            //s = null;
            //WriteLine(s.GetHashCode());
            //char c = 'd';
            // WriteLine(c.GetHashCode());


            //float f = 0.1f;
            //WriteLine(f.GetHashCode());
            //WriteLine(int.MinValue);
            //A a1 = new(), a2 = new();
            //var v = a1 > a;
            //Console.WriteLine(comparer(4, 5));
            //object o = new();

            //string s = "1";
            //f(s);
            //Console.WriteLine($"i = {s}");
            //    MemoryStopwatch sw = new();
            //    Operation op = Operation.Add;
            // //   Console.WriteLine(op.GetHashCode());
            //    op = Operation.Multiply;
            ////    Console.WriteLine(op.GetHashCode());
            //    sw.Start();
            //    (int, int) tuple = (5, 10), tuple1 = (5, 10);
            //    Console.WriteLine(tuple.GetHashCode());
            //    Console.WriteLine(tuple1.GetHashCode());
            //    Console.WriteLine(sw.Next());

            //    sw.Start();
            //    object o = new();
            //    Console.WriteLine(sw.Next());

            //    int i = 1, j = 1;
            //    object o1 = new();
            //    string s = "", s1 = "";
            //    Console.WriteLine($"{i.GetHashCode()} {j.GetHashCode()} {o.GetHashCode()}" +
            //                      $" {o1.GetHashCode()} {s.GetHashCode()} {s1.GetHashCode()}");
        }

    }
}
