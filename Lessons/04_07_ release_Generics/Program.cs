// Ковариантность обобщений. (delegate)

Pet? pet;
var shop = new Petshop();

Func<Pet> getPet = shop.CatCreator;
pet = getPet.Invoke();

Console.WriteLine(pet.GetType().FullName);

abstract class Pet { }
class Cat : Pet { }
class Dog : Pet { }

class Petshop
{
    public Cat CatCreator() => new Cat();
    public Dog DogCreator() => new Dog();
}