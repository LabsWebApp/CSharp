using static System.Console;

// Создаём класс-делегата с именем Delegate,
// метод, который будет сообщен с экземпляром данного класса-делегата, 
// не будет ничего принимать и не будет ничего возвращать.
public delegate void Delegate();  //1

// Класс, метод которого будет сообщен с делегатом.
class SimpleClass
{
    public void Method() => WriteLine("Строку вывел метод сообщенный с делегатом.");
    public static void StaticMethod() => WriteLine("Строку вывел метод сообщенный с делегатом.");
}

class Programm
{
    public static void Main()
    {

        Delegate simpleDelegate = null;//== null
        var instance = new SimpleClass();

        simpleDelegate = instance.Method; // Создаем экземпляр делегата. (2)
        simpleDelegate += SimpleClass.StaticMethod;
        simpleDelegate -= SimpleClass.StaticMethod;
        simpleDelegate -= instance.Method;
        simpleDelegate?.Invoke(); // Вызываем метод сообщенный с делегатом. (3)
        simpleDelegate();//Другой способ вызова метода сообщенного с делегатом. (3')

        instance.Method();
    }
}