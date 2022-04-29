using System.Collections;
using Yield;
using static System.Console;

var items = UserCollection.Power();
WriteLine(items.GetType().FullName);
WriteLine(items.GetType().Name);
foreach (string element in items)
{
    WriteLine(element);
    break;
}
foreach (string element in items)
    WriteLine(element);


WriteLine(new string('-', 12));

// Примерно так работает foreach.

var enumerable = UserCollection.Power();

var enumerator = enumerable.GetEnumerator();

while (enumerator.MoveNext()) // Перемещаем курсор на 1 шаг вперед.
{
    var element = enumerator.Current as string;

    WriteLine(element);
}

ReadKey();