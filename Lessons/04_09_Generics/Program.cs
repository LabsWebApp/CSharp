// Так делать нельзя!!!

var aInt = new A<int>();
var sum = aInt.Add(2, 3);
Console.WriteLine(sum);

var aObj = new A<object>();
var res = aObj.Add(2, 3);
Console.WriteLine(res);



class A<T>
{
    public T Add(T a, T b) => typeof(T).Name switch
    {
        "Int32" => (T)(object)((int)(object)a! + (int)(object)b!),
        "Int64" => (T)(object)((long)(object)a! + (long)(object)b!),
        "Double" => (T)(object)((double)(object)a! + (double)(object)b!),
        _ => (T)(object)0
    };
}