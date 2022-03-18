using static System.Console;
// Лямбда выражения и лямбда операторы.

namespace Delegate;

// Создаем класс делегата.
public delegate double Delegate(int a);
public delegate void VoidDelegate();

//public delegate double D1(double p1);

//public delegate double D2(D1 p1);

class Program
{
    static void Main()
    {
        //D1 d1 = p1 => p1 * p1;
        //D2 d2 = p1 => Math.Sqrt(p1.Invoke(10));


        //Delegate simpleDelegate;

        ////Console.WriteLine(simpleDelegate.GetHashCode());

        //simpleDelegate = delegate (int x) { return x * 1; }; // Лямбда-Метод 

        //WriteLine(simpleDelegate.GetHashCode());

        //simpleDelegate = x => ++x * 2;         // Лямбда-Оператор.

        //simpleDelegate = _ => 55;

        //WriteLine(simpleDelegate.GetHashCode());

        //double i = 2;

        //simpleDelegate = _ => (int)(i * 5);             // Лямбда-Выражение.
        //i = 10;

        //WriteLine(simpleDelegate(4));

        //// Delay.
        //ReadKey();

        VoidDelegate action;

        action = delegate { WriteLine("Hello 1"); }; // Лямбда-Метод 

        action += () => { WriteLine("Hello 2"); };   // Лямбда-Оператор.

        action += () => WriteLine("Hello 3");        // Лямбда-Выражение.


        action();
    }
}