// Ковариантность обобщений. (delegate)

Pet? pet;
Delegate<Pet>? delegatePet;

Petshop shop = new Petshop();
Delegate<Cat> delegateCat = new Delegate<Cat>(shop.CatCreator);
Delegate<Dog> delegateDog = shop.DogCreator;



delegatePet = delegateCat;    // От производного к базовому.
                              // ****
delegatePet = delegateDog;    // От производного к базовому.
                              // ***
delegatePet = delegateCat;

pet = delegatePet.Invoke();

Console.WriteLine("Мы купили: " + pet.GetType().Name);

abstract class Pet { }
class Cat : Pet { }
class Dog : Pet { }
class Hamster : Pet { }

class Petshop
{
    public Cat CatCreator() => new Cat();
    public Dog DogCreator() => new Dog();
}

delegate TResult Delegate<out TResult>();   // out - Для возвращаемого значения.