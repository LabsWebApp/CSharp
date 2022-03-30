// ReSharper disable All
using static System.Console;

namespace Delegate.Events;

// Событие, это не что иное, как ситуация, при возникновении которой,
// ничего не произойдёт или произойдет действие или несколько действий.
// Говоря языком программного моделирования,
// Событие — это именованный делегат, при вызове которого,
// будут запущены все подписавшиеся на момент вызова события методы заданной сигнатуры. 
//

public delegate void MethodContainer();
public class ClassCounter
{
    private readonly short _zeroHour;

    //Событие OnCount c типом делегата MethodContainer.
    public event MethodContainer OnCount;

    public ClassCounter(short zeroHour = 8)
    {
        _zeroHour = zeroHour;
        SetControl();
    }

    private short _count;

    public void Count()
    {
        while (true)
        {
            _count++;
            Thread.Sleep(1000);
            if (_count % _zeroHour == 0) OnCount?.Invoke();
        }
        // ReSharper disable once FunctionNeverReturns
    }

    //protected virtual void Invoker() => OnCount?.Invoke();

    public void SetControl()
    {
        OnCount -= OnOnCount;
        OnCount += OnOnCount;
    }

    private void OnOnCount()
    {
        if (_count >= short.MaxValue - _zeroHour) _count = 0;
    }
}

//Это класс, реагирующий на событие (счет кратен zeroHour) записью строки в консоли.
internal class Vasja
{
    public void VMessage()
    {
        WriteLine();
        WriteLine("***********");
        WriteLine(" *********");
        WriteLine("  *******");
        WriteLine("   *****");
        WriteLine("    ***");
        WriteLine("     *");
        WriteLine("     *");
        WriteLine("     *");
        WriteLine("    ***");
        WriteLine("  *******");
        WriteLine($"{nameof(Vasja)}: Надо остограмиться!\n");
    }
}

internal class Kolya
{
    public void KMessage()
    {
        WriteLine();
        WriteLine("    0                        0");
        WriteLine("   00                        00");
        WriteLine("   00                        00");
        WriteLine("  000                        000");
        WriteLine("**000************************000**");
        WriteLine("  000                        000");
        WriteLine("   00                        00");
        WriteLine("   00                        00");
        WriteLine("    0                        0");
        WriteLine($"{nameof(Kolya)}: Пора в качалку!\n");
    }
}

internal class Program
{
    private static void M() => WriteLine("Mmmmmmmmmm.....");
    static void Main()
    {
       // SetWindowSize(1,1);
        ClassCounter counter = new();
        //counter.SetControl();
        //counter.Count(); 

        Vasja vasja = new();
        Kolya kolya = new();

        //Подписались на событие
        counter.OnCount += vasja.VMessage;
        counter.OnCount -= vasja.VMessage;
        //counter.OnCount += kolya.KMessage;
        counter.OnCount += kolya.KMessage;
        counter.OnCount += M;

        counter.Count();
    }
}