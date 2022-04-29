using System.Collections;

namespace SimpleVsGeneric;

public class UserCollection
{
    public const int Max = 10000000;
    public static IEnumerable Power()
    {
        for (var i = 0; i < Max; i++) yield return i;
    }
}