using System.Numerics;
using Enumerations.Extension;
using Enumerations.Extension.Disposes;


Action writeSep = () => WriteLine("*****");

foreach (var item in 0) WriteLine(item);
SetResetColor.ForAction(ConsoleColor.Green, writeSep);

foreach (var item in 10) WriteLine(item);
SetResetColor.ForAction(ConsoleColor.Red, writeSep);

foreach (var item in -10) WriteLine(item);
SetResetColor.ForAction(ConsoleColor.Yellow, writeSep);

//foreach (var item in int.MaxValue) Console.WriteLine(item);
//SetResetColor.ForAction(ConsoleColor.Blue, writeSep);

IEnumerable<BigInteger> collection = 3.GetEnumerator(i => (BigInteger)long.MaxValue * i);
foreach (var item in collection) WriteLine(item);
SetResetColor.ForAction(ForegroundColor, writeSep);



foreach (var item in NumberExtension.StepRange(3, 10, i => i + 2))
    WriteLine(item);


ReadLine();