using System.Collections;

IEnumerable Power()
{
    while (true) yield return "Hello world!";

    //for (;;) yield return "Hello world!";

//step:
//    yield return "Hello world!";
//    goto step;
}

foreach (string element in Power())
{
    Console.WriteLine(element);
    //Thread.Sleep(1);
    //break;
}