// ReSharper disable VirtualMemberCallInConstructor
using static System.Console;

namespace SolidL;

//SOLID

//3. L - Liskov substitution
//принцип подстановки Барбары Лисков
//наследуемый класс должен дополнять, а не замещать базовый


//не верно
abstract class Bird
{
    public abstract void Fly();
}

class Duck : Bird
{
    public override void Fly() => WriteLine("Уточка полетела!");
}

class Ostrich : Bird
{
    public override void Fly() => throw new Exception("Страус не умеет летать!");
}

//верно

//abstract class Bird { }

//abstract class FlyingBird : Bird
//{
//    public abstract void Fly();
//}

//class Duck : FlyingBird
//{
//    public override void Fly() => WriteLine("Уточка полетела!");
//}
//class Ostrich : Bird { }