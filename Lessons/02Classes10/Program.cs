using static System.Console;


//Инкапсуляция и сокрытие.
/*
R r = new() { A = 2, B = 3 };

WriteLine(r);
WriteLine(r.S);

ReadKey();

record struct R(int A, int B)
{
    //public int A { get; init; }
    //public int B { get; init; }
    public int S => A * B;

    private string? PrepareToString() => A == 0 || B == 0 ? "пусто" : null;
    public override string ToString() => PrepareToString() ?? $"A = {A}; B = {B}";
}
*/

//Наследование
//Всё является System.Object или просто object
/*
class Person
{
    public Person() => Name = "noname";
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; init; }

    private int _year;
    public int Age
    {
        get => DateTime.Now.Year - new DateTime(_year,1,1).Year;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("gfghhgf");
            _year = value > 1900 ? value : DateTime.Now.Year - value;
        }
    }
}

class Employer : Person
{
    public double Salary { get; set; }
    public Employer(){}
    public Employer(string name) : base(name)
    {
    }

    public Employer(string name, double salary) : this(name)
    {
        Salary = salary;
    }
}

enum Layer 
{
    Frontend,
    Backend,
    FullStack
}

class Programmer : Employer
{
    public Layer Layer { get; set; }

    //public Programmer(string name) : base(name)
    //{
    //}

    //public Programmer(string name, double salary) : base(name, salary)
    //{
    //}
}
*/

//(модификаторы доступа)

//Абстрактный классы
/*
abstract class A
{
    public string? Name { get; set; }
    public int I { get; set; } = 1;
    protected A(){}
    protected A(string Name, int i)
    {
        this.Name = Name;
        I = i;
    }

    public abstract void Print();
}

class B : A
{
    public B(string name, int _) : base(name, _)
    {
        I = 99;
    }

    internal static B GetB(int i)
    {
        return new B("noname", i) { I = i };
    }

    public override void Print() => WriteLine("это В!");
}
*/

//Интерфейсы
/*
IPrintable p = new P(); 
p.Print();
p = new Pi();
p.Print();

internal interface IPrintable
{
    void Print();

    void PrintType()
    {
        WriteLine(this.GetType().FullName);
    }
}

class P : IPrintable
{
    public string? S { get; set; }

    void IPrintable.Print() => WriteLine("Привет, это Р явный!");
    public void Print() => WriteLine("Привет, это Р!");
    public void PrintType() => WriteLine("Тип Р");
}

internal class Pi : IPrintable
{
    public int I { get; set; }
    public void Print() => WriteLine("Привет, это Рi!");
}
*/

//Полиморфизм

//Мнимый ad-hock 

//перегрузка 

//var a = new A();
//a.f(5, 6);
//a.f("5", "6");
//class A
//{
//    public void f(int x, int y) => WriteLine($"C.f({x + y})");
//    public void f(string x, string y) => WriteLine($"C.f({x + y})");
//}

////переопределение
//class C
//{
//    public virtual void f(int x) => WriteLine("C.f(int)"); 
//}

//class D : C
//{
//    public override void f(int x) => WriteLine("D.f(int)"); 
//}


//Упаковка boxing - unboxing
/*
int i = 123;
//Упаковка i:
object o = i;

object o1 = 456;
//Распаковка i:
i = (int)o1;

i = 55;
WriteLine(o1);
*/
//Композиция и агрегация

var car = new Car();
car.Drive();
var grenade = new Grenade();

var AgrCar = new Car(grenade);
var room = new Room(grenade);

class Car
{
    public Wheel[]? Wheels { get; init; }
    public Engine? Engine { get; init; }

    public Grenade? Grenade { get; set; }

    public Car()
    {
        Engine = new Engine(this);
        Wheels = new Wheel[4]
        {
            new Wheel(this),
            new Wheel(this),
            new Wheel(this),
            new Wheel(this)
        };
    }

    public Car(Grenade grenade)
    {
        Grenade = grenade;
    }

    public void Drive()
    {
        Engine?.Drive();
        for (var i = 0; i < Wheels?.Length; i++)
        {
            Wheels[i].Drive();
        }
    }
}

class Engine
{
    public Car? Owner { get; }
    public Engine() => Owner = null;
    public Engine(Car? owner) => Owner = owner;

    public void Drive()
    {
        if (Owner is null) throw new Exception("Двигатель не работает без машины!");
        WriteLine("Движок работает)");
    }
}

class Wheel
{
    public Car? Owner { get; }
    public Wheel() => Owner = null;
    public Wheel(Car? owner) => Owner = owner;

    public void Drive() => WriteLine("Колесо крутится)");
}

class Grenade
{
    
}

class Room
{
    public Grenade? Grenade { get; set; }

    public Room(Grenade grenade) => Grenade = grenade;
}
