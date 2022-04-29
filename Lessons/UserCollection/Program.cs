using System.Numerics;
using Enumerations.UserCollections;
using Microsoft.Win32.SafeHandles;

namespace Enumerations;

// Коллекция это такой объект, к-ый можно использовать в качестве source в цикле foreach
// требования к объекту-source в цикле foreach
// он должен иметь метод GetEnumerator(), 
// который возвращает другой объект или самого себя со следующими требованиями
//   - должен иметь метод bool MoveNext()
//   - должен иметь свойство T Current { get; }

public class Program
{
    // TFunc -> 
   

    public class Items<T> where T : IComparable 
    {
        public Items<T> GetEnumerator()
        {
            _value = _minusOne;
            return this;
        }

        public T Current
        {
            get
            { 
                if (_value!.Equals(_minusOne))
                    throw new InvalidOperationException(
                        "Перечисление не запущено. Необходимо вызвать MoveNext.");
                return _value;
            }
        }

        public bool MoveNext()
        {
            if (_value.CompareTo(_max) < 0) 
            {
                _value = _increment(_value);
                return true;
            }

            _value = _minusOne;
            return false;
        }

        //
        private T _value;
        private readonly T _max;
        private readonly T _minusOne;
        private readonly Func<T, T> _increment;

        public Items(T max, Func<T, T> increment, T minusOne)
        {
            _max = max;
            _increment = increment;
            _minusOne = minusOne;
            _value = minusOne;
        }
    }


    public static void Main()
    {
        Thread.CurrentThread.Priority = ThreadPriority.Highest;

        Items<BigInteger> items = new(
            new BigInteger(long.MaxValue) * long.MaxValue, 
            b => ++b, 
            BigInteger.MinusOne); 
        foreach (var item in items)
        {
            if (item % 100000000 == 0)
                Console.WriteLine($"{item}");
        }

        Console.ReadKey();









        var s = "0123456789";
        Console.WriteLine(s);

        using var str = s.GetEnumerator();
        Console.WriteLine(str.GetType().FullName);
        Console.WriteLine(str.GetType().Name);

        //Console.WriteLine(str.Current);
        str.MoveNext();
        Console.WriteLine(str.Current);
        str.MoveNext();
        Console.WriteLine(str.Current);
        str.MoveNext();
        Console.WriteLine(str.Current);

        Console.Write(new string('-', 29) + "\n");

        foreach (var item in s)
        {
            Console.WriteLine(item);
        }

        Console.Write(new string('-', 29) + "\n");

        Console.ReadKey();

        //UserCollection userCollection = new UserCollection();

        ////Console.WriteLine(userCollection.Current ?? "нету");

        //// Используем foreach, для обращения к каждому объекту Element внутри массива userCollection. 
        //foreach (Element element in userCollection)
        //{
        //    Console.WriteLine(element);
        //    break;
        //}
        ////Console.ReadKey();
        ////userCollection.Reset(); // Убрать комментарий для проверки.

        //Console.Write(new string('-', 29) + "\n");

        //// Используем foreach, для повторного обращения к каждому объекту Element внутри массива userCollection.
        //foreach (Element element in userCollection)
        //{
        //    Console.WriteLine(element);
        //}
        //userCollection.Reset();

        //Console.Write(new string('-', 29) + "\n");

        //Console.ReadKey();

        // ----------------------------------------------------------------------------------------------------------------------
        // Так работает foreach.

        var elementsCollection = new UserCollection();

        // Перемещаем курсор на 1 шаг вперед (с -1 на 0) и т.д.
        var enumerator = elementsCollection.GetEnumerator();
        while (enumerator.MoveNext())
        { 
            var element = elementsCollection.Current as Element;

            element = new Element("New", 0, 1);

            Console.WriteLine(element);
        }


        elementsCollection.Reset();

        Console.Write(new string('-', 29) + "\n");

        foreach (Element element in elementsCollection)
        {
            //element = new Element("new", 0, 1);
            element.Name = "New";
            element.Property1 = 0;
            element.Property2 = 1;
            Console.WriteLine(element);
        }

        // Задержка.
        Console.ReadKey();
    }
}


