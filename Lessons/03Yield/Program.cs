using Yield;

foreach (var element in UserCollection.Power())
    Console.WriteLine(element);

var items = UserCollection.Power();

Console.WriteLine(items.GetType().FullName);
Console.WriteLine(items.GetType().Name);
Console.ReadKey();