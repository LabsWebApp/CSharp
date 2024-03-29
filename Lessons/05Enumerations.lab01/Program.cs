﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UseGC;
using static System.Console;

namespace Enumerations.lab01
{
    class Program
    {
        private const int TestLength = 1500000;

        private static readonly Random R = new((int)DateTime.Now.Ticks);
        private const int RandomMaxValue = int.MaxValue;

        private static int Next(int maxValue = RandomMaxValue) => R.Next(maxValue);
        
        public static int[] Array(long count)
        {
            var numbers = new int[count]; 
            for (var i = 0; i < count; ++i)
                numbers[i] = Next();
            return numbers;
        }

        public static IEnumerable<int> Iterator(long count, Func<int, int> get = null)
        {
            get ??= i => i;
            for (var i = 0; i < count; ++i)
                yield return get(i);
        }

        public static List<int> GetList(long count, Func<int, int> get = null)
        {
            get ??= i => i;
            var result = new List<int>();
            for (var i = 0; i < count; ++i)
                result.Add(get(i));
            return result;
        }

        static void Main(string[] args)
        {
            var test = 0;
            bool TestPredicate(int i) => i % 9 == 0;

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
                if (TestPredicate(i)) test++;
            sw.Stop();
            Logging(test, ms.Next(), sw.ElapsedMilliseconds, iterator);

            test = 0;
            sw.Start();
            ms.Start();
            foreach (var i in list)
                if (TestPredicate(i)) test++;
            sw.Stop();
            Logging(test, ms.Next(), sw.ElapsedMilliseconds, list);

            var ii = 0;
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
