using static System.Console;

// Создаём класс-делегата с именем Delegate,
// метод, который будет сообщен с экземпляром данного класса-делегата, 
// не будет принимать один параметр типа object и будет возвращать тип string.
public delegate string Delegate(object name);   //1

// Класс, метод которого будет сообщен с делегатом.
class SimpleClass
{
    public string Method(object name)
    {
        return "Hello " + name;
    }
    public string Method(int id)
    {
        return "Привет " + id;
    }
}

class Programm
{
    public static void Main()
    {
        var instance = new SimpleClass();

        Delegate simpleDelegate = instance.Method; // Создаем экземпляр делегата и сообщаем с ним метод. (2)

        // Вызываем метод сообщенный с делегатом. (3)
        var greeting = simpleDelegate.Invoke("Jeffrey Richter");

        WriteLine(greeting);

        var i = 55;
        greeting = simpleDelegate(i); // Другой способ вызова метода сообщенного с делегатом. (3')

        WriteLine(greeting);

        greeting = instance.Method(i);
        WriteLine(greeting);
    }
}