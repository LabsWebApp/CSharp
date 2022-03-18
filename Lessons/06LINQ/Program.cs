using System;
using static System.Console;
using System.Linq;

namespace LINQ
{
    class Program
    {
        class A
        {
            public string Name { get; set; }
            public int I { get; set; }

            public override string ToString()
            {
                return Name + " " + I.ToString();
            }
        }
        static void Main(string[] args)
        {
            var collection = new UserCollection(1);
            //WriteLine(collection);

            //SELECT + ToArray()

            dynamic test = from x in collection select x; // test = collection.GetEnumerator();

            //WriteLine(test.GetType());
            //WriteLine(collection.GetType());


            //WriteLine(UserCollection.Get(test));

            //ReadKey();
            var c = (5, "ggg", '5', DateTime.Now);
            var u = new { Namber = 5, Str = "ggg", Ch = '5', Time = DateTime.Now };

            //WriteLine(c.GetType().Name);
            //WriteLine(c);

            //WriteLine(u.GetType().Name);
            //WriteLine(u);
           
            //<T1,...Tn> (T1 x1, T2 x2,... Tn xn)
            //new { Name1 = x1, ... Namen = xn};

            test = from x in collection select new {N = x.Name, I = x.Number};


            //foreach (var item in test) WriteLine(item);
            

            test = collection.Select(x => x); // ~= collection.GetEnumerator();
            //WriteLine(UserCollection.Get(test));
            test = collection.Select(y => (y.Name, y.Number));
            //foreach (var item in test) WriteLine(item);
            //test = collection.Select(x => new {x.Name, x.Number});
            //foreach (var item in test) WriteLine(item);
         
            //WHERE
            test = 
                from x in collection 
                where x.Name.ToLower().Contains("a") 
                select x;
            //WriteLine(UserCollection.Get(test));
            ReadKey();
            test = collection.Select(x => x).Where(y => y.Name.ToLower().Contains("a"));
            //WriteLine(UserCollection.Get(test));
            test = collection.Where(y => y.Name.ToLower().Contains("a"));
            //WriteLine(UserCollection.Get(test));
            //ReadKey();
            //LET
            test =
                from x in collection
                let name = $"Какое имя: \"{x.Name}\""
                let number = x.Number * x.Number
                select (name, number, x.Id);

           //foreach (var item in test) WriteLine(item);
           
            WriteLine();
            test = collection
                .Select(x => new
                {
                    x, name = $"Какое имя: \"{x.Name}\""
                })
                .Select(x => new
                {
                    x, number = x.x.Number * x.x.Number
                })
                .Select(x => (x.x.name, x.number, x.x.x.Id));

           //foreach (var item in test) WriteLine(item);
          
            //Сложный запрос
            var collectionTwo = new UserCollection(2);
           // WriteLine(collectionTwo);

            test = 
                from x in collection
                from y in collectionTwo 
                where x.Number == y.Number
                select (x.Name, y.Name);

            //foreach (var item in test) WriteLine(item);
            ReadKey();
            test = collection.SelectMany(
                    _ => collectionTwo, 
                    (x, y) => (x, y))
                .Where(t => t.x.Number == t.y.Number)
                .Select(xt => (xt.x.Name, xt.y.Name));
            //foreach (var item in test) WriteLine(item);

            var a1 = new int[] {1, 2, 3, 4, 5};
            var a2 = new int[] { 1, 6, 3, 8, 5 };


            //foreach (var item in a1.Union(a2)) WriteLine(item);

            ReadKey();
        }
    }
}
