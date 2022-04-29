// Контравариантность обобщений. (delegate)

using static System.Console;

var cat = new Cat();
Action<Cat>? sCat = null;

var vet = new Vet();

sCat = vet.Sterilize;

sCat.Invoke(cat);

abstract class Pet { }
class Cat : Pet { }
class Dog : Pet { }

class Vet
{
    public void Sterilize(Pet pet) =>
        WriteLine($"У {pet.GetType().Name} не будет деток(((");
}