using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace GenericsTest;

[MemoryDiagnoser]
[RankColumn]
public class CollectionsBenchmark
{
    [Benchmark(Description = "Simple - IEnumerable")]
    public void SimpleCollectionTest()
    {
        var collection = SimpleVsGeneric
            .UserCollection
            .Power();

        var result = BigInteger.Zero;
        foreach (var item in collection) result += (int)item;
    }

    [Benchmark(Description = "Generic - IEnumerable<int>")]
    public void GenericCollectionTest()
    {
        var collection = SimpleVsGeneric
            .UserCollectionGeneric
            .Power();

        var result = BigInteger.Zero;
        foreach (var item in collection) result += item;
    }
}