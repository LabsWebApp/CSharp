delegate bool CheckChar(char ch);
//delegate void CheckChar2(char ch1, char ch2);

class DelegatesContainer<TDelegate, TMulticastDelegate>
    where TDelegate : Delegate
    where TMulticastDelegate : MulticastDelegate
{
    public TDelegate SimpleDelegate { get; set; }
    public TMulticastDelegate MultiDelegate { get; set; }

    public DelegatesContainer(TDelegate simpleDelegate, TMulticastDelegate multiDelegate)
    {
        SimpleDelegate = simpleDelegate;
        MultiDelegate = multiDelegate;
    }









    private void Test()
    {
        var list1 = SimpleDelegate.GetInvocationList();
        var list2 = MultiDelegate.GetInvocationList();
    }
}

class Programm
{
    private static void Hello() { Console.WriteLine("Hello"); }
    private static void Hi() { Console.WriteLine("Hi"); }

    public static void Main()
    {
        //Action action = () => Console.WriteLine("jhghjg");
        //Predicate<char> predicate = ch => ch == ' ';
        CheckChar check;

        string exp = "6776rgAAaaah00bbbzzjbhjZZZbzsgfSFGH25856!!!!&&0&";
        Console.WriteLine(exp);

        bool CheckElement(char ch) => ch is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        check = CheckElement;
        Console.WriteLine(CheckString(check, exp));

        Console.ReadKey();
        bool CheckElementAandZ(char ch) => ch is 'a' or 'z' or 'A' or 'Z';

        Console.WriteLine(check('0'));
        Console.WriteLine(check('a'));
        Console.ReadKey();

        check = CheckElementAandZ;
        Console.WriteLine(CheckString(check, exp));

        Console.ReadKey();

        check = _ =>
        {
            Console.WriteLine("jhvjhgh");
            return true; ;
        };
        check += ch => ch != '1';
        Console.WriteLine(CheckString(check, "01AaZzuhgiuhiufdhz"));

        //CheckChar2 checkChar2 = (_,_) => Console.WriteLine("jhvjhgh");

        //checkChar2.Invoke('1', '2');

    }

    static string CheckString(CheckChar ch, string source)
    {
        string result = string.Empty;
        ch = c => c == 0;

        for (int i = 0; i < source.Length; i++)
        {
            if (ch(source[i])) result += source[i];
        }

        return result;
    }
}