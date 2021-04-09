using System;
using static System.Console;

namespace Delegate
{
    /*
    Ковариантностью
    называется сохранение иерархии наследования исходных типов 
    в производных типах в том же порядке.
    
    Контравариантностью
    называется обращение иерархии исходных типов 
    на противоположную в производных типах.
    */

    class Person
    {
        public string Name { get; init; }

        //для дженериков 
        public virtual void Display() => WriteLine($"Person {Name}");
    }

    class Client : Person
    {
        //для дженериков 
        public override void Display() => WriteLine($"Client {Name}");
    }

    class Program
    {
        #region ковариантность
        delegate Person PersonFactory(string name);
        static Client BuildClient(string name)
            => new Client { Name = name };
        #endregion

        #region контравариантность
        delegate void ClientInfo(Client client);

        static void GetPersonInfo(Person p)
            =>
                WriteLine($"Имя: {p.Name} ({p.GetType().FullName})");
        #endregion

        #region ковариантный обобщенный делегат 
        delegate T Builder<out T>(string name);

        static Person CreatePerson(string name) => new() { Name = name };
        static Client CreateClient(string name) => new () { Name = name };
        #endregion

        #region контравариантный обобщенный делегат 
        delegate void GetInfo<in T>(T item);

        static void DisplayPersonInfo(Person p) => p.Display();
        static void DisplayClientInfo(Client cl) => cl.Display();
        #endregion

        #region "делегат делегата"

        delegate void V();

        delegate V DV(V v1, V v2, bool add = true);

        #endregion

        static void Main()
        {
            #region ковариантность
            PersonFactory personDelegate;
            personDelegate = BuildClient; // 
            var p = personDelegate("Петя");
            //WriteLine($"Имя: {p.Name} ({p.GetType().FullName})");
            #endregion

            #region контравариантность
            ClientInfo clientInfo = GetPersonInfo;
            Client client = new Client { Name = "Маша" };

            //clientInfo(client);
            /*
            Несмотря на то, что делегат в качестве параметра принимает 
            объект Client, ему можно присвоить метод,
            принимающий в качестве параметра объект базового типа Person.
            Может показаться на первый взгляд,
            что здесь есть некоторое противоречие,
            то есть использование более универсального тип вместо более производного.
            Однако в реальности в делегат при его вызове мы все равно 
            можем передать только объекты типа Client,
            а любой объект типа Client является объектом типа Person, 
            который используется в методе.
             */
            //так проверить:
            //GetPersonInfo(client);
            #endregion

            #region ковариантный обобщенный делегат 
            Builder<Client> clientBuilder = CreateClient;
            Builder<Person> personBuilder1 = clientBuilder;     // или ниже
            Builder<Person> personBuilder2 = CreateClient;         //

            Person person = personBuilder1("Ваня"); // вызов делегата
            //person.Display();
            person = personBuilder2("Ваня"); // вызов делегата
            //person.Display();
            #endregion

            #region контравариантный обобщенный делегат 
            GetInfo<Person> displayPersonInfo = DisplayPersonInfo;
            GetInfo<Client> displayClientInfo = displayPersonInfo;      // контравариантность

            Client contraClient = new Client { Name = "Мая" };
            //displayClientInfo(contraClient); //

            Person p1 = new Person{Name = "Саша"};
            //displayClientInfo((Client)p1);
            #endregion

            V v1 = () => Write("v1 "),
                v2 = () => Write("v2 ");

            DV dv = (v1, v2, add) =>
            {
                WriteLine("add or sub");
                return add ? v1 + v2 : v1 - v2;
            };
            //v1();
            ReadKey();
            //dv.Invoke(v1, v2);
            V res = dv(v1, v2);
            res();
            WriteLine();
            res = dv(res, v1, false);
            res();
            ReadKey();



            //int obj = 0;
            //VoidFunction f1, f2, f3, f4;
            //f1 = (ref int sender, int arg) 
            //    => sender = sender + arg;
            //f2 = (ref int sender, int arg)
            //    => sender = arg == 0 ? sender : sender * arg;


            //ComplexVoidFunction functional = (component1, component2) =>
            //    component1 + component2;

            //functional(f1)?.Invoke(ref obj, 1);

            //WriteLine(obj);

            //obj = 0;
            //functional(f1, f2)?.Invoke(ref obj, 10);

            //WriteLine(obj);

            //Operation del1 = Add;
            //Operation del2 = new Operation(Add);

            //WriteLine($"{Functional(f1)?.Invoke(ref obj, 1)} {del2.GetHashCode()}");


            //// присваивание адреса метода через контруктор
            //Operation del = Add; // делегат указывает на метод Add
            //int result = del(4, 5); // фактически Add(4, 5)
            //Console.WriteLine(result);
            //Console.WriteLine(del.GetHashCode());

            //del = Multiply; // теперь делегат указывает на метод Multiply
            //result = del(4, 5); // фактически Multiply(4, 5)
            //Console.WriteLine(result);
            //Console.WriteLine(del.GetHashCode());
            //ReturnString 
            //    delegate1 = () => "Hello ", 
            //    delegate2 = () => "world!";

            //Functional functional = delegate(ReturnString d1, ReturnString d2) 
            //    { return delegate() { return d1.Invoke() + d2.Invoke(); }; };
            ////Functional functional = delegate(ReturnString d1, ReturnString d2) { return () => d1.Invoke() + d2.Invoke(); };
            ////Functional functional = (ReturnString d1, ReturnString d2) => () => d1() + d2();

            ////Console.WriteLine((functional.Invoke(delegate1,delegate2)).Invoke());
            //Console.WriteLine(functional(delegate1, delegate2)());

            //Anonim a = delegate (int x, int y, int w) { return (x +  y + w) / 3;
            //};

            //Console.WriteLine(a(2,3,4));
            //Console.ReadKey();


            //Console.ReadKey();
        }

        //private static int Multiply(int x, int y)
        //{
        //    return x * y;
        //}

        //private static int Add(int x, int y)
        //{
        //    return x + y;
        //}
    }
}
