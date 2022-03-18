// Так делать нельзя!!!

A<int> aInt = new A<int>();
int sum = aInt.Add(2, 3);
Console.WriteLine(sum);

A<object> aObj = new A<object>();
object res = aObj.Add(2, 3);
Console.WriteLine(res);

class A<T>
{
    public T Add(T a, T b) => typeof(T).Name switch
    {
        "Int32" => (T)(object)((int)(object)a! + (int)(object)b!),
        "Double" => (T)(object)((double)(object)a! + (double)(object)b!),
        _ => (T)(object)0
    };
}