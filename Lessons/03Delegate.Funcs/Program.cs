using System;
using System.Collections.Generic;
using static System.Console;

namespace Delegate.Funcs
{
    class Program
    {
        #region Action
        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2) op(x1, x2);
        }
        static void Add(int x1, int x2)
            => WriteLine("Сумма чисел: " + (x1 + x2));
        static void Subtract(int x1, int x2)
            => WriteLine("Разность чисел: " + (x1 - x2));
        #endregion

        #region Func
        static int GetInt(int x, Func<int, int> retF)
        {
            int result = 0;
            if (x > 0)
                result = retF(x);
            return result;
        }

        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++) result *= i;
            return result;
        }
        #endregion

        #region Ко(контра)вариантность на пальцах
        /// <summary>
        /// Абстрактный питомец
        /// </summary>
        abstract class Pet
        {
            private bool _sterile = false;
            /// <summary>
            /// Сообщает и изменяет информацию
            /// о стерильности животного
            /// </summary>
            public bool Sterile
            {
                get => _sterile;
                set
                {
                    if (value && !_sterile) _sterile = true;
                }
            }
        }
        /// <summary>
        /// Котик
        /// </summary>
        class Cat : Pet { }
        /// <summary>
        /// Собачка
        /// </summary>
        class Dog : Pet { }
        /// <summary>
        /// Хомячок
        /// </summary>
        class Hamster : Pet { }

        /// <summary>
        /// Переопределяет Action из System, инкапсуляция метода,
        /// который ничего не возвращает и имеет один параметр
        /// </summary>
        /// <typeparam name="T">любой тип данных</typeparam>
        /// <param name="obj">объект для работы метода</param>
        delegate void Action<in T>(T obj);

        /// <summary>
        /// Переопределяет Func из System, инкапсуляция метода,
        /// который возвращает экземпляр или переменную
        /// произвольного типа
        /// </summary>
        /// <typeparam name="TResult">произвольный тип</typeparam>
        /// <returns>объект типа TResult</returns>
        delegate TResult Func<out TResult>();

        /// <summary>
        /// Зоомагазин
        /// </summary>
        static class Petshop
        {
            private static readonly Hamster Hamster1 = new ();
            public static Func<Hamster> SellHamster { get; } 
                = () => Hamster1;
        }

        /// <summary>
        /// Ветеринар
        /// </summary>
        class Vet
        {
            /// <summary>
            /// Основная работа ветеринара
            /// </summary>
            public Action<Pet> Sterilize { get; } =
                p => p.Sterile = true;
        }
        
        #endregion
        static void Main(string[] args)
        {
            #region делегат делегата

            Func<Action, Action, Action> dd;
            dd = (a1, _) => a1;
           // dd(() => WriteLine("a1"), null).Invoke();
            dd = (a1, a2) =>
            {
                a2?.Invoke();
                a1?.Invoke();
                return a1 + a2;
            };
            Action mainD = dd(
                () => WriteLine("a1"),
                () => WriteLine("a2"));
            ReadKey();
            mainD();

            #endregion
            ReadKey();
            #region Action
            Action a = delegate { WriteLine("Hi"); };
            //a();
            Action<int, int> op;
            op = Add;
            //Operation(10, 6, op);
            op = Subtract;
            //Operation(10, 6, op);
            #endregion

            #region Predicate
            Predicate<int> isPositive = delegate (int x) { return x > 0; };

            //WriteLine(isPositive(20));
            //WriteLine(isPositive(-20));
            #endregion

            #region Func

            Func<bool> isAm = () => DateTime.Now.Hour < 12;
            //WriteLine(isAm ());

            Func<int, int> retFunc = Factorial;
            int n1 = GetInt(6, retFunc);
            //WriteLine(n1);
            n1 = GetInt(0, retFunc);
            //WriteLine(n1);

            int n2 = GetInt(6, x => x * x);
            //WriteLine(n2);
            #endregion

            #region Ко(контра)вариантность на пальцах
            //Задача I: купить какого-нибудь питомца
            //(ко)

            //Нужно найти метод:
            Func<Pet> getPet = default;

            //Нашёлся зоомагазин с хомячками
            Func<Hamster> getHamster = Petshop.SellHamster;
            //Берём, что есть
            getPet = getHamster;

            //Покупаем питомца
            Pet pet = getPet();
            //WriteLine($"Купили питомца: {pet.GetType().Name.ToLower()}.");

            //Задача II: кастрировать конкретного котика
            //(контра)

            //Создаём(берём) котика
            Cat cat = new Cat();
            
            //Нужно найти метод:
            Action<Cat> sterilize = default;

            /*
             * Создаём(ищем) ветеринара,
             * который умеет стерилизовать домашних животных
             */
            Vet vet = new ();
            sterilize = vet.Sterilize;

            //Проводим операцию
            sterilize(cat);

            if (cat.Sterile)
                WriteLine("У котика больше не будет котят(((");
            #endregion
            
            ReadKey();
        }
    }
}
