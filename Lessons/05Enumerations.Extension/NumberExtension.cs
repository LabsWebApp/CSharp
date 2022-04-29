namespace Enumerations.Extension;

internal static class NumberExtension
{
    internal static IEnumerator<int> GetEnumerator(this int number)
    {
        var k = number > 0 ? number : 0;
        for (var i = number - k; i <= k; i++) yield return i;
    }

    internal static IEnumerable<T> GetEnumerator<T>(this int number, Func<int, T> f)
    {
        var k = number > 0 ? number : 0;
        for (var i = number - k; i <= k; i++) yield return f(i);
    }

    internal static IEnumerable<T> StepRange<T>(T start, T end, Func<T, T> step)
       where T : IComparable<T>
    {
        while (start.CompareTo(end) <= 0)
        {
            yield return start;
            start = step(start);
        }
    }
}