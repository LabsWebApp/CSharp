using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Int32;

namespace AsyncAwait
{
    class Program
    {
        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(10000);
            WriteLine($"Факториал равен {result}");
        }

        static async void FactorialAsync()
        {
            WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(Factorial);                // выполняется асинхронно
            WriteLine("Конец метода FactorialAsync");
        }

        static void Main()
        {
            //Task.Run(() => Parallel.For(0, 10, i =>
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        Write("*");
            //    }
            //    WriteLine();
            //}));

            FactorialAsync();   // вызов асинхронного метода

            WriteLine("Введите число: ");
            int n = Parse(ReadLine() ?? string.Empty);
            WriteLine($"Квадрат числа равен {n * n}");

            Read();
        }
    }
}
