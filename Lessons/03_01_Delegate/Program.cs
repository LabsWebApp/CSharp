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
    public static void Method() => WriteLine("StaticClass: Строку вывел метод сообщенный с делегатом.");
}

class Class
{
    public void Method() => WriteLine("Class: Строку вывел метод сообщенный с делегатом.");
}

class Programm
{
    public static void Main()
    {
        Delegate? simpleDelegate;
        simpleDelegate = null;

        simpleDelegate = StaticClass.Method; // Создаем экземпляр делегата. (2)

        //WriteLine(simpleDelegate is MulticastDelegate);

        //Class instance = new Class();

        //simpleDelegate += instance.Method;

        //simpleDelegate += () => WriteLine("Лямбда: Строку вывел метод сообщенный с делегатом.");

        //simpleDelegate += StaticClass.Method;
        //simpleDelegate -= StaticClass.Method;

        simpleDelegate?.Invoke(); // Вызываем метод сообщенный с делегатом. (3)
        //simpleDelegate!();//Другой способ вызова метода сообщенного с делегатом. (3')


        


        
    }
}