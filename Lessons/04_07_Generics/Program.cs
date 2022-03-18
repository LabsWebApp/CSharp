// Ковариантность обобщений. (delegate)

Pet? pet;
Petshop shop = new Petshop();

Delegate<Pet>? delegatePet;
Delegate<Cat> delegateCat = new Delegate<Cat>(shop.CatCreator);

delegatePet = delegateCat;    // От производного к базовому.                      
pet = delegatePet.Invoke();

Console.WriteLine(pet.GetType().Name);

abstract class Pet { }
class Cat : Pet { }
class Dog : Pet { }

class Petshop
{
    public Cat CatCreator() => new Cat();
    public Dog DogCreator() => new Dog();
}

delegate T Delegate<out T>();   // out - Для возвращаемого значения.






//Func<Pet> getPet = shop.CatCreator;
//pet = getPet.Invoke();