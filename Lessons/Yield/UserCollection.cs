using System.Collections;

namespace Yield;

class UserCollection
{
    public static IEnumerable<string> Power()
    {
        yield return "Привет, Петя!";
        yield return "Привет, Маша!";
        yield return 99.ToString();
    }
}