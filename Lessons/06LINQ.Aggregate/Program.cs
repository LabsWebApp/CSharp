int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
var size = (from i in numbers where i % 2 == 0 && i > 10 select i).Count();
Console.WriteLine(size);