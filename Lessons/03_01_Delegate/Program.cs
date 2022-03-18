using static System.Console;

// Создаём класс-делегата с именем Delegate,
// метод, который будет сообщен с экземпляром данного класса-делегата, 
// не будет ничего принимать и не будет ничего возвращать.
public delegate void Delegate();  //1

// Класс, метод которого будет сообщен с делегатом.
static class StaticClass
{
    static StaticClass() => WriteLine("Создан \"невидимый\" экземпляр");

    // Создаем статический метод, который планируем сообщить с делегатом.
    public static void Method() => WriteLine("Строку вывел метод сообщенный с делегатом.");
}

class Programm
{
    public static void Main()
    {
        Delegate? simpleDelegate; //== null

        simpleDelegate = StaticClass.Method; // Создаем экземпляр делегата. (2)

        simpleDelegate?.Invoke(); // Вызываем метод сообщенный с делегатом. (3)
        simpleDelegate!();//Другой способ вызова метода сообщенного с делегатом. (3')


        


        //StaticClass.Method();
        WriteLine("****");
        simpleDelegate += WriteLine;

        simpleDelegate.Invoke();

        WriteLine("****");

        //simpleDelegate += WriteLine;
        simpleDelegate -= WriteLine;
        simpleDelegate -= StaticClass.Method;
        simpleDelegate?.Invoke();

        

        simpleDelegate = delegate { WriteLine("gcfcjgjj"); };
        simpleDelegate -= delegate { WriteLine("gcfcjgjj"); };

        simpleDelegate?.Invoke();
        ReadKey();

        simpleDelegate = () => WriteLine("lamda");
        simpleDelegate -= () => WriteLine("lamda");

        simpleDelegate?.Invoke();
        simpleDelegate!();
        //WriteLine();
        WriteLine("****");
    }
}