// ReSharper disable VirtualMemberCallInConstructor

//SOLID

//3. L - Liskov substitution
//принцип подстановки Барбары Лисков
//наследуемый класс должен дополнять, а не замещать базовый


//не верно
/*
abstract class Bird
{
    public virtual void Fly() { }
}

class Duck : Bird { }

class Ostrich : Bird
{
    public override void Fly()
    {
        throw new Exception("Страус не умеет летать!");
    }
}
*/
//верно
abstract class Bird { }

abstract class FlyingBird : Bird
{
    public void Fly() { }
}

class Duck : FlyingBird { }
class Ostrich : Bird { }
