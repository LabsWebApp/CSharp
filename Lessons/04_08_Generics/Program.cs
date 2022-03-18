// Контравариантность обобщений. (delegate)
using static System.Console;

Cat cat = new Cat();
Delegate<Cat>? sCat = null;

Vet vet = new Vet();
Delegate<Animal> sAnimal = vet.Sterilize;

sCat = sAnimal;
sCat.Invoke(cat);

abstract class Animal { }
class Cat : Animal { }
class Dog : Animal { }

class Vet
{
    public void Sterilize(Animal animal) =>
        WriteLine($"У {animal.GetType().Name} не будет деток(((");
}

delegate void Delegate<in T>(T animal);