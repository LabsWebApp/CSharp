using System;
using static System.Console;


namespace _04Generic
{
    class A<T>
    {
        public T[] Properties { get; init; }

        public T GetFirst(Predicate<T> filter)
        {
            foreach (var prop in Properties)
                if (filter(prop))
                    return prop;
            return default;
        }


    }
    //class A
    //{
    //    private double _r = 10;

    //    //логика вычислений 

    //    public double CulcWithRadius(Func<double, double> f) => f(_r);
    //}


    //class Account
    //{
    //    public virtual void DoTransfer(int sum)
    //    {
    //        Console.WriteLine($"Клиент положил на счет {sum} долларов");
    //    }
    //}

    //class DepositAccount : Account
    //{
    //    public override void DoTransfer(int sum)
    //    {
    //        Console.WriteLine($"Клиент положил на депозитный счет {sum} долларов");
    //    }
    //}

    //interface IBank<out T>
    //{
    //    T CreateAccount(int sum);
    //}

    //class Bank<T> : IBank<T> where T : Account, new()
    //{
    //    public T CreateAccount(int sum = 0)
    //    {
    //        T acc = new T();  // создаем счет
    //        acc.DoTransfer(sum);
    //        return acc;
    //    }
    //}

    //interface ITransaction<T>
    //{
    //    void DoOperation(T account, int sum);
    //}

    //class Transaction<T> : ITransaction<T> where T : Account
    //{
    //    public void DoOperation(T account, int sum)
    //    {
    //        account.DoTransfer(sum);
    //    }
    //}


   // delegate double F(double d);
    class Program
    {

        //static double cLen(double r)
        //{
        //    return 2 * Math.PI * r;
        //}
        static void Main(string[] args)
        {
            A<int> a = new A<int>
            {
                Properties = new[] {-1, 55, 888, -99}
            };

          //  Predicate<int> f = i => i > 100;

            WriteLine(a.GetFirst(i => i > 100));

            //Func<double, double> f;
            //f = cLen;
            //WriteLine(a.CulcWithRadius(f));


            //WriteLine(a.CulcWithRadius(r => 2 * Math.PI * r));


            //WriteLine(a.CulcWithRadius(r => r));


            // A a = new();
            // Func<double, double> f;
            // f = d => d; 
            //WriteLine(a.CulcWithRadius(f));

            //WriteLine(a.CulcWithRadius(r => 2 * Math.PI * r));



            //Action[] actions = new Action[100];

            //for (int i = 0; i < 100; i++)
            //    actions[i] = () => WriteLine(i);

            //actions[0]();
            //actions[5]();
            //actions[99]();

            //actions[100]();





            //var s = A<string>.g = "sdgfjg";
            //Console.WriteLine(s);

            //var i = A<int>.g = 55;
            //Console.WriteLine(i);
            //ITransaction<Account> accTransaction = 
            //    new Transaction<Account>();
            //accTransaction.DoOperation(new Account(), 400);

            //ITransaction<DepositAccount> depAccTransaction = 
            //    new Transaction<Account>();
            //depAccTransaction.DoOperation(new DepositAccount(), 450);

            Console.Read();
        }
    }
}
