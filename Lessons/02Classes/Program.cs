using static System.Console;

namespace Classes
{
    public interface IDdd
    {
        void Ddd(); //{ WriteLine(this); }
    }

    public class Aa
    {
        public void Ddd() { WriteLine(this); }
    }

    class Father
    {
        
    }

    class Son : Father
    {
        
    }

    class Daughter : Father
    {

    }

    class Program
    {
        

        //static private MemoryStopwatch sw = new MemoryStopwatch();

       // static private object o = new();

        //private A a = new();
        //static int m(int i = 0, int j = 0) => i + j;
        //static int m(params int[] @params) => 
        //    @params.ToList().Sum();

        static void Main(string[] args)
        {
            Aa a = new();
            var ddd = a as IDdd;
            WriteLine(ddd != null);
            ReadKey();

            var s = new Son();
            var f = (Father) s;
            var d = (Daughter) f;

            WriteLine(d.GetType());
            // var start = new Startup();
            //start.main();
        }

       
    }
}
