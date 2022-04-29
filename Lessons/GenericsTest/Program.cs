using BenchmarkDotNet.Running;
using GenericsTest;

BenchmarkRunner.Run<CollectionsBenchmark>();

Console.ReadKey();