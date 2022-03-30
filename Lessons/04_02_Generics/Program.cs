Console.WriteLine("bmbjkb");
class Generics<Type1, Type2>
{
    // Поля
    private Type1 variable1;
    private Type2 variable2;

    // Конструктор.
    public Generics(Type1 argument1, Type2 argument2)
    {
        this.variable1 = argument1;
        this.variable2 = argument2;
    }

    // Свойства.
    public Type1 Variable1
    {
        get { return this.variable1; }
        set { this.variable1 = value; }
    }

    public Type2 Variable2
    {
        get { return this.variable2; }
        set { this.variable2 = value; }
    }
}
