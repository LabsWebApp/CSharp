using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Threading;
using UseGC;
using static System.Console;

namespace Enumerations.lab01
{
    class Program
    {
        const int TestLength = 150000000;

        private static Random _r = new((int)DateTime.Now.Ticks);
        private const int RandomMaxValue = int.MaxValue;

        private static int Next(int maxValue = RandomMaxValue) => _r.Next(maxValue);
        
        public static int[] Array(long count)
        {
            var numbers = new int[count]; 
            for (var i = 0; i < count; ++i)
                numbers[i] = Next();
            return numbers;
        }

        //public static IEnumerable<int> Iterator(long count)
        //{
        //    for (var i = 0; i < count; ++i)
        //        yield return Next(); ;
        //}

        public static IEnumerable<int> Iterator(long count, Func<int, int> get = null)
        {
            get ??= i => i;
            for (var i = 0; i < count; ++i)
                yield return get(i);
        }

        public static List<int> GetList(long count, Func<int, int> get = null)
        {
            get ??= i => i;
            List<int> result = new List<int>();
            for (var i = 0; i < count; ++i)
                result.Add(get(i));
            return result;
        }

        static void Main(string[] args)
        {
            int test = 0;
            Predicate<int> testPredicate = i => i % 9 == 0;

            Stopwatch sw = new();
            MemoryStopwatch ms = new();

            WriteLine("***************************INIT***************************");
            sw.Start();
            ms.Start();
            var ints = Array(TestLength);
            sw.Stop();
            Logging(ints.Length, ms.Next(), sw.ElapsedMilliseconds, ints);

            sw.Start();
            ms.Start();
            var iterator = Iterator(TestLength);
            Logging(iterator.Count(), ms.Next(), sw.ElapsedMilliseconds, iterator);

            sw.Start();
            ms.Start();
            var list = GetList(TestLength);
            Logging(list.Count(), ms.Next(), sw.ElapsedMilliseconds, list);
            ReadKey();

            WriteLine("\n***************************TEST***************************");
            sw.Start();
            ms.Start();
            foreach (var i in iterator)
                if (testPredicate(i)) test++;
            sw.Stop();
            Logging(test, ms.Next(), sw.ElapsedMilliseconds, iterator);

            test = 0;
            sw.Start();
            ms.Start();
            foreach (var i in list)
                if (testPredicate(i)) test++;
            sw.Stop();
            Logging(test, ms.Next(), sw.ElapsedMilliseconds, list);

            int ii = 0;
            Func<int, int> f = _ => ii;
            var newIterator = Iterator(TestLength, f);
            ii = 1;
            ReadKey();
            WriteLine(newIterator.FirstOrDefault());
            ReadKey();
        }

        private static void Logging(int test, long mem, long time, object sender)=>
            WriteLine($"{sender.GetType().Name}: результат теста = {test} (память = {mem}; время = {time}).");


    }
}
