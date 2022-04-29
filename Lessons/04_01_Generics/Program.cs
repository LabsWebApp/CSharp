// Универсальные шаблоны. (обобщения, дженерики)

// Создаем экземпляр класса Class и в качестве параметра типа (тип Class) передаем тип int.
var instance1 = new Class<int>();
instance1.Method();

// Создаем экземпляр класса Class и в качестве параметра типа (тип Class) передаем тип long.
var instance2 = new Class<long>();
instance2.Method();

// Создаем экземпляр класса Class и в качестве параметра типа (тип Class) передаем тип string.
var instance3 = new Class<string>();
instance3.field = "ABC";
instance3.Method();

// Создаем класс с именем Class, параметризованный Указателем Места Заполнения Типом - T
class Class<T>
{
    public T field;

    public void Method() => 
        Console.WriteLine(field?.GetType().FullName ?? "Какой-то ссылочный тип");
}