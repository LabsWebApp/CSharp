// Универсальные шаблоны. (Универсальный метод)

A instance = new A();

instance.Method<string>("Hello world!");

instance.Method("Привет мир!");

instance.Method(55);

class A
{
    public void Method<T1>(T1 argument)
    {
        T1 variable = argument;
        Console.WriteLine($"{variable} - {variable!.GetType()}");
    }
}