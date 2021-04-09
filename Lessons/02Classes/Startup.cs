using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
using System.Threading.Tasks;
using UseGC;

namespace Classes
{
    //interface IS
    //{
    //    int S();
    //}

    //abstract class NSites
    //{
    //    protected int a = default;
    //    public int A
    //    {
    //        get => a;
    //    }
    //    public abstract int S();
    //}
    
    ////record R(int ID, string Name);
    //class Qu : NSites
    //{
        

    //    //public int S => a * a;

        
    //   public Qu() : this(5) { }
    //   public Qu(int a) => this.a = a;
    //   public override int S() => a * a;
    //}

    //class Rec: NSites
    //{
    //    private int b;

    //    public int B
    //    {
    //        get => b;
    //    }

    //    public override int S() => a * b;
    //}

    class A
    {
        private int i;

        public static string str = "str";
        public static int S() => 10;
    }
    static class staticClass
    {
        public static string s;

        static staticClass() => WriteLine("создались");
    }

    class Startup
    {
        public void main()
        {
            ReadKey();
            staticClass.s =  "nfghf" ;
        }
    }
}
