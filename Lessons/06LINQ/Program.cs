using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new UserCollection(1);
            //WriteLine(collection);

            //SELECT + ToArray()

            dynamic test = from x in collection select x;

            //WriteLine(UserCollection.Get(test));

            //<T1,...Tn> (T1 x1, T2 x2,... Tn xn)
            // new { Name1 = x1, ... Namen = xn};

            test = from x in collection select (x.Name, x.Number);

            //foreach (var item in test) WriteLine(item);

            test = collection.Select(x => x);
            //WriteLine(UserCollection.Get(test));
            test = collection.Select(x => (x.Name, x.Number));
            // foreach (var item in test) WriteLine(item);
            test = collection.Select(x => new {x.Name, x.Number});
            //foreach (var item in test) WriteLine(item);

            //WHERE
            test = from x in collection where x.Name.ToLower().Contains("a") select x;
            //WriteLine(UserCollection.Get(test));

            test = collection.Select(x => x).Where(y => y.Name.ToLower().Contains("a"));
            //WriteLine(UserCollection.Get(test));
            test = collection.Where(y => y.Name.ToLower().Contains("a"));
            //WriteLine(UserCollection.Get(test));

            //LET
            test =
                from x in collection
                let name = $"Какое имя: \"{x.Name}\""
                let number = $"А число ещё лучше: {x.Number} )))"
                select (name, number);

            //foreach (var item in test) WriteLine(item);
            //WriteLine();
            test = collection
                .Select(x => new
                {
                    x, name = $"Какое имя: \"{x.Name}\""
                })
                .Select(t => new
                {
                    t, number = $"А число ещё лучше: {t.x.Number} )))"
                })
                .Select(xt => (xt.t.name, xt.number));

           // foreach (var item in test) WriteLine(item);

            //Сложный запрос
            var collectionTwo = new UserCollection(2);
           // WriteLine(collectionTwo);

            test = 
                from x in collection
                from y in collectionTwo
                where x.Number == y.Number
                select (x.Name, y.Name);

            foreach (var item in test) WriteLine(item);

            test = collection.SelectMany(
                    _ => collectionTwo, 
                    (x, y) => (x, y))
                .Where(t => t.x.Number == t.y.Number)
                .Select(xt => (xt.x.Name, xt.y.Name));
            foreach (var item in test) WriteLine(item);

            ReadKey();
        }
    }
}
