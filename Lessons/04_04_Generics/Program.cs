// Универсальные шаблоны. (Универсальный делегат)

static int Double(int i) => i + i;

static string Concatenation(string s) => "Привет, " + s + "!";



Delegate<int, int> delegate1 = new Delegate<int, int>(Double);

int i = delegate1.Invoke(5);
Console.WriteLine(i);

Delegate<string, string> delegate2 = new Delegate<string, string>(Concatenation);
string s = delegate2("Alex");
Console.WriteLine(s);


// Создаем класс-делегата с именем  Delegate,
// параметризованный двумя Указателями Места Заполнения Типом - Т и R,
// метод который будет сообщен с экземпляром данного класса-делегата,
// будет принимать один аргумент, типа Указателя Места Заполнения Типом - Т,
// и возвращать значение типа Указателя Места Заполнения Типом - R.
delegate R Delegate<T, R>(T t);