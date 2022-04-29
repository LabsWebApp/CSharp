using System.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Dia2Lib;
using static System.Console;


BenchmarkRunner.Run<BenchmarkDictionaryTest>();

[MemoryDiagnoser]
[RankColumn]
public class BenchmarkDictionaryTest
{
    public BenchmarkDictionaryTest() => Filling();

    private const int Test = 10000;
    private string _first = string.Empty, 
        _middle = string.Empty, 
        _last = string.Empty;

    private readonly SortedDictionary<string, object> _sortedDictionary = new();
    private readonly Dictionary<string, object> _dictionary = new();
     
    private readonly Random _random = new(DateTime.Now.Millisecond);

    private string NewElement(ICollection<string> old)
    {
        var ch = (char)_random.Next('a', 'z');
        var result = ch.ToString();
        var i = 0;
        while (old.Contains(result)) result = $"{result[0]}{i++}";
        return result;
    }

    private void Filling()
    {
        for (var i = 0; i < Test; i++)
        {
            var result = NewElement(_dictionary.Keys);
            switch (i)
            {
                case 0:
                    _first = result;
                    break;
                case Test / 2:
                    _middle = result;
                    break;
                case Test - 1:
                    _last = result;
                    break;
            }
            _dictionary.Add(result, result);
            _sortedDictionary.Add(result, result);
        }
    }

    //[Benchmark(Description = "Simple")]
    public void SearchingTest()
    {
        var last = _dictionary[_last];
        var first = _dictionary[_first];
        var middle = _dictionary[_middle];
    }

    //[Benchmark(Description = "Sorted")]
    public void SortedSearchingTest()
    {
        var last = _sortedDictionary[_last];
        var first = _sortedDictionary[_first];
        var middle = _sortedDictionary[_middle];
    }

    [Benchmark(Description = "Simple")]
    public void AddRemoveTest()
    {
        _dictionary.Remove(_last);
        _dictionary.Add(_last, string.Empty);

        _dictionary.Remove(_first);
        _dictionary.Add(_first, string.Empty);

        _dictionary.Remove(_middle);
        _dictionary.Add(_middle, string.Empty);
    }

    [Benchmark(Description = "Sorted")]
    public void SortedAddRemoveTest()
    {
        _sortedDictionary.Remove(_last);
        _sortedDictionary.Add(_last, string.Empty);

        _sortedDictionary.Remove(_first);
        _sortedDictionary.Add(_first, string.Empty);

        _sortedDictionary.Remove(_middle);
        _sortedDictionary.Add(_middle, string.Empty);
    }

    //[Benchmark(Description = "Simple")]
    public void ContainsTest()
    {
        var hasFirst = _dictionary.ContainsKey(_first);
        var hasLast= _dictionary.ContainsKey(_last);
        var hasMiddle = _dictionary.ContainsKey(_middle);
    }

    //[Benchmark(Description = "Sorted")]
    public void SortedContainsTest()
    {
        var hasFirst = _sortedDictionary.ContainsKey(_first);
        var hasLast = _sortedDictionary.ContainsKey(_last);
        var hasMiddle = _sortedDictionary.ContainsKey(_middle);
    }
}