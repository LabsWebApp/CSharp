// Анонимные лямбда методы.

// Создаем класс делегата.
public delegate void Delegate();

class Program
{
    static void Main()
    {
        // Создаем экземпляр класса-делегата Delegate и сообщаем с ним анонимный метод.

        Delegate simpleDelegate;
        simpleDelegate = delegate
        {
            Console.WriteLine("Hello world!");
        };


        // Вызов анонимного метода, сообщенного с делегатом.
        simpleDelegate();
        Console.WriteLine("****");

        simpleDelegate += () => { Console.WriteLine("add"); };
        simpleDelegate += () => { Console.WriteLine("add"); };
        simpleDelegate -= () => { Console.WriteLine("add"); };
        //simpleDelegate = simpleDelegate () => Console.WriteLine("add");

        simpleDelegate();
        Console.ReadKey();


        Console.WriteLine("****");
        simpleDelegate -= () => { Console.WriteLine("add"); };
        simpleDelegate();
        Console.WriteLine("****");
        // Delay.
        Console.ReadKey();
    }
}