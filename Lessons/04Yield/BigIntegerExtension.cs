using System.Collections;
using System.Numerics;

namespace Yield;

static class NumberExtension
{
    public static IEnumerable Range(this BigInteger number)
    {
        if (number <= 0)
        {
            yield return BigInteger.Zero;
            yield break;
        }
        for (var i = BigInteger.Zero; i <= number; i++)
        {
            yield return i;
        }
    }

    public static IEnumerable Range(this int number)
    {
        if (number <= 0)
        {
            yield return 0;
            yield break;
        }
        for (var i = 0; i <= number; i++)
        {
            yield return i;
        }
    }

    public static IEnumerable SelectRange<T>(this BigInteger number, Func<BigInteger, T> func)
    {
        if (number <= 0)
        {
            yield return BigInteger.Zero;
            yield break;
        }
        for (var i = BigInteger.Zero; i <= number; i++)
        {
            yield return func(i);
        }
    }
}