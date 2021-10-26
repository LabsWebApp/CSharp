using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using static System.Console;

namespace Delegate.Funcs
{
    class Program
    {
        #region Action
        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2) op?.Invoke(x1, x2);
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

        /*
         * Ковариантностью
         * называется сохранение иерархии наследования исходных типов 
         * в производных типах в том же порядке.
         *  
         * Контравариантностью
         * называется обращение иерархии исходных типов 
         * на противоположную в производных типах.
         */

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
                    WriteLine($"{GetType().Name} is {(_sterile ? "sterile" : "not sterile")}.");
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
        /// Переопределяет Func из System, инкапсуляция метода,
        /// который возвращает экземпляр или переменную
        /// произвольного типа
        /// </summary>
        /// <typeparam name="TResult">произвольный тип</typeparam>
        /// <returns>объект типа TResult</returns>
        delegate TResult Func<out TResult>();

        /// <summary>
        /// Переопределяет Action из System, инкапсуляция метода,
        /// который ничего не возвращает и имеет один параметр
        /// </summary>
        /// <typeparam name="T">любой тип данных</typeparam>
        /// <param name="obj">объект для работы метода</param>
        delegate void Action<in T>(T obj);

        /// <summary>
        /// Зоомагазин
        /// </summary>
        static class Petshop
        {
            private static readonly Hamster Hamster1 = new ();
            private static readonly Cat Cat1 = new ();
            public static Func<Hamster> SellHamster { get; } 
                = () => Hamster1;
            public static Func<Cat> SellCat { get; } 
                = () => Cat1;
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

        #region Ко(контра)вариантность в интерфейсах
        interface ICovariance<out T>
        {
            T Get();
        }

        abstract class CoPet<T> : ICovariance<T> where T : Pet
        {
            public abstract T Get();
        }

        class CoCat : CoPet<Cat>
        {
            public override Cat Get() => new();
        }

        interface IContravariance<in T>
        {
            void Do(T param);
        }

        class ContraPet<T> : IContravariance<T> where T : Pet
        {
            public void Do(T param) => WriteLine(param.GetType().Name);
        }
        #endregion

        static void Main(string[] args)
        {
            {
                /*#region делегат делегата
                
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
                            ReadKey();*/
            }

            #region Action
            //Action a = delegate { WriteLine("Hi"); };
            ////a();
            //Action<int, int> op;
            //op = Add;
            //Operation(10, 6, op);
            //op = Subtract;
            //Operation(10, 6, op);
            //Operation(6, 10, op);
            //ReadKey();
            #endregion

            #region Predicate
            Predicate<int> isPositive = delegate (int x) { return x > 0; };

            //WriteLine(isPositive(20));
            //WriteLine(isPositive(-20));
            #endregion

            #region Func
            //Func<bool> isAm = () => DateTime.Now.Hour < 12;
            //WriteLine(isAm());

            //Func<int, int> retFunc = Factorial;
            //int n1 = GetInt(6, retFunc);
            //WriteLine(n1);
            //n1 = GetInt(0, retFunc);
            //WriteLine(n1);

            //int n2 = GetInt(6, x =>
            //{
            //    return x * x;
            //});
            //WriteLine(n2);
            //ReadKey();
            #endregion

            #region Ко(контра)вариантность на пальцах
            //Задача I: купить какого-нибудь питомца
            //(ко)

            //Нужно найти метод:
            Func<Pet> getPet = default;

            IList<Pet> gifts = new List<Pet>();

            //Нашёлся зоомагазин с хомячками
            Func<Hamster> getHamster = Petshop.SellHamster;
            
            //Берём, что есть
            getPet = getHamster;

            //Покупаем питомца
            Pet pet1 = getPet();
            gifts.Add(pet1);
            //WriteLine($"Купили питомца: {pet1.GetType().Name.ToLower()}.");
            getPet = Petshop.SellCat;
            Pet pet2 = getPet();
            //WriteLine($"Купили питомца: {pet2.GetType().Name.ToLower()}.");
            //ReadKey();

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
            //sterilize(cat);

            //if (cat.Sterile)
            //    WriteLine("У котика больше не будет котят(((");
            //ReadKey();
            #endregion

            #region Ко(контра)вариантность в интерфейсах

            ICovariance<object> co = new CoCat();

            IContravariance<Pet> contra = new ContraPet<Pet>();
            contra.Do(new Cat());
            #endregion


            ReadKey();
        }
    }
}
