using System;
using static System.Console;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using ForI;
using UseGC;

namespace Classes
{
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
            var s = new Son();
            var f = (Father) s;
            var d = (Daughter) f;

            WriteLine(d.GetType());
            // var start = new Startup();
            //start.main();
        }

       
    }
}
