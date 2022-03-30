//Ограничения на обобщения 

//class Class<TA, TII, TAII, TNotNull, TClass, TClassWithDefaultNew, TStruct>
//    where TA : A
//    where TII : II
//    where TAII : A, II
//    where TNotNull : notnull
//    where TClass : class
//    where TClassWithDefaultNew : class
//    where TStruct : struct
//{
//    public TNotNull NotNullProperty { get; set; }
//    public Class(TNotNull notNullProperty)
//    {
//        NotNullProperty = notNullProperty;

//        TA value = new();
//    }


//}

//interface II
//{
//    void Method() { }
//}
//class A
//{
//    public A() { }
//    public A(int i) { }
//}

//class B : A
//{
//    public B() { }
//    public B(int i) : base(i)
//    {
//    }
//}
//class C : A, II
//{
//    public C(int i) : base(i)
//    {
//    }
//}

// Некоторые типы не могут использоваться как ограничение базового класса:
//      Object, Array и ValueType.
// Но их кол-во сокращается, теперь можно:
//public class UsingEnum<T> where T : System.Enum { }

//public class UsingDelegate<T> where T : System.Delegate
//{
//    //private T t;
//    //private void V() => t.GetInvocationList()
//}
//public class Multicaster<T> where T : System.MulticastDelegate { }


//unmanaged
// 1. sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, или bool
// 2. Любой тип перечисления
// 3. Любой тип указателя
// 4. Начиная с C# 8.0, сконструированный тип структуры,
// содержащий поля только неуправляемых типов, также является неуправляемым,
//как показано в следующем примере:

DisplaySize<Coords<int>>();
DisplaySize<Coords<long>>();

static unsafe void DisplaySize<T>() where T : unmanaged =>
    Console.WriteLine($"{typeof(T)} является неуправляемым, размер: {sizeof(T)}B");

struct Coords<T>
{
    public T X;
    public T Y;
}
