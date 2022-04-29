// Контравариантность обобщений. (delegate)

using static System.Console;

var cat = new Cat();
Delegate<Cat>? sCat = null;

var vet = new Vet();
Delegate<Pet> sPet = vet.Sterilize;

sCat = sPet;
//****
sCat.Invoke(cat);


abstract class Pet { }
class Cat : Pet { }
class Dog : Pet { }

class Vet
{
    public void Sterilize(Pet pet) =>
        WriteLine($"У {pet.GetType().Name} не будет деток(((");
    //***
}

delegate void Delegate<in TParam>(TParam pet);