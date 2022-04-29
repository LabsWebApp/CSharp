using System.Collections;
#pragma warning disable CS0162

namespace Yield;

public class UserCollection
{
    public static IEnumerable Power()
    {
        try
        {
            yield return 99;
            yield return "Hi";
            yield break;
            yield return "Дай!";
            Console.WriteLine("почти всё");
        }
        finally
        {
            //yield return "Дай!";
            Console.WriteLine("всё");
        }
    }
}