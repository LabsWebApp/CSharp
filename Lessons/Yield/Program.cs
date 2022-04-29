using Yield;
using static System.Console;


var col = UserCollection.Power();
WriteLine(col.GetType().FullName);
WriteLine(col.GetType().Name);

foreach (var element in UserCollection.Power())
{
    WriteLine(element);
}
ReadKey();

WriteLine(new string('-', 12));

//-----------------------------------------------------------------------------------------------
// Так работает foreach.

var enumerable = UserCollection.Power();
var enumerator = enumerable.GetEnumerator();

while (enumerator.MoveNext()) // Перемещаем курсор на 1 шаг вперед.
{
    var element = enumerator.Current;
    WriteLine(element);
}

ReadKey();
