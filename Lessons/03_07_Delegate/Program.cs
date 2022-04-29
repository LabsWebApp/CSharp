using static System.Console;
// Анонимные (лямбда) методы.

namespace Delegate;

// Создаем класс делегата.
public delegate void Delegate(ref int a, in int b, out int c);

public delegate void Delegate1(int a, int b, int c);
public delegate int Delegate2(int a);

class Cont
{
    public int X { get; set; }
}

class Program
{
    static void m(int i) => i = 99;

    static void m(Cont i) => i.X = 99;

    static void Main()
    {
        //int i = 5;
        //Cont i2 = new Cont();
        //i2.X = 5;

        //m(i);
        //m(i2);

        //WriteLine(i);
        //WriteLine(i2.X);

        //ReadKey();


        int summand1 = 1, summand2 = 2;

        Delegate simpleDelegate = delegate (ref int a, in int b, out int c)
        {
            a++;
            c = a + b;
        };

        simpleDelegate.Invoke(ref summand1, in summand2, out var sum);

        WriteLine($"{summand1} + {summand2} = {sum}");

        //ReadKey();
        simpleDelegate = (ref int a, in int b, out int c)
            =>
        {
            a++;
            //b++;
            c = a + b;
        };
        simpleDelegate.Invoke(ref summand1, in summand2, out sum);
        simpleDelegate.Invoke(ref summand1, in summand2, out sum);

        WriteLine($"{summand1} + {summand2} = {sum}");
        ReadKey();



        Delegate1 dreturnInt = (a, _, _)
            =>
        {
            a++;

        };
        dreturnInt.Invoke(summand1, summand2, sum);
        //simpleDelegate(ref summand1, summand2, out sum);

        WriteLine($"{summand1} + {summand2} = {sum}");

        Delegate2 d2 = i => i++;

        // Delay.
        ReadKey();
    }
}
