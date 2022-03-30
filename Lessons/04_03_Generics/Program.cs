// Универсальные шаблоны. (Универсальный метод)

A instance = new A();

instance.Method<string>("Hello world!");

instance.Method("Привет мир!");

instance.Method(55);

class A
{
    public void Method<T>(T argument)
    {
        T variable = argument;
        Console.WriteLine($"{variable} - {variable!.GetType()}");
    }
}