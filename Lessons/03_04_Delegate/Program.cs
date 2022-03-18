using static System.Console;
// Комбинированные (групповые) делегаты.

class Programm
{
    delegate void Delegate();
    delegate int IntDelegate(int i);

    //delegate void Delegate1();

    static void Method1() => WriteLine("Method1");
    static void Method2() => WriteLine("Method2");
    static void Method3() => WriteLine("Method3");

    static int Method4(int i)
    {
        WriteLine("*****");
        return ++i;
    } 

    public static void Main()
    {
        Delegate baseDelegate;
        Delegate simpleDelegate1 = new Delegate(Method1);
        Delegate simpleDelegate2 = Method2;
        Delegate simpleDelegate3 = Method3;

        IntDelegate intDelegate1 = Method4;
        IntDelegate intDelegate2 = Method4;

        IntDelegate baseIntDelegate = intDelegate1 + intDelegate2;

        WriteLine(baseIntDelegate.Invoke(0));
        WriteLine("*****");
        // Комбинируем делегаты.
        baseDelegate = simpleDelegate1 + simpleDelegate2 + simpleDelegate3;

        baseDelegate += simpleDelegate2;
        baseDelegate.Invoke();
        WriteLine("*****");
        baseDelegate -= simpleDelegate2;
        baseDelegate.Invoke();

        while (true)
        {
            WriteLine("Введите число от 1 до 8");
            string? choice = ReadLine();

            switch (choice)
            {
                case "1":
                {
                    simpleDelegate1.Invoke();
                    break;
                }
                case "2":
                {
                    simpleDelegate2.Invoke();
                    break;
                }
                case "3":
                {
                    simpleDelegate3.Invoke();
                    break;
                }
                case "4":
                {
                    Delegate simpleDelegate4 = (baseDelegate - simpleDelegate1)!;
                    simpleDelegate4.Invoke();
                    break;
                }
                case "5":
                {
                    Delegate simpleDelegate5 = (baseDelegate - simpleDelegate2)!;
                    simpleDelegate5.Invoke();
                    break;
                }
                case "6":
                {
                    Delegate simpleDelegate6 = (baseDelegate - simpleDelegate3)!;
                    simpleDelegate6.Invoke();
                    break;
                }
                case "7":
                {
                    Delegate simpleDelegate7 = (baseDelegate - simpleDelegate3 - simpleDelegate1 - simpleDelegate2);
                    WriteLine(simpleDelegate7 is object);
                    simpleDelegate7?.Invoke();
                    break;
                }
                case "8":
                {
                    baseDelegate.Invoke();
                    break;
                }
                default:
                {
                    WriteLine("Вы ввели недопустимое значение.");
                    break;
                }
            }

        }
    }
}