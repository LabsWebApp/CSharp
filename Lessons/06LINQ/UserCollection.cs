using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class UserCollection : IEnumerable<Element>
    {
        private readonly Element[] _elements;

        public IEnumerator<Element> GetEnumerator()
        {
            foreach (var element in _elements)
                yield return element;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var element in _elements)
            {
                sb.Append(element);
                sb.Append('\n');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Инициализация коллекции по заранее созданным сценариям
        /// </summary>
        /// <param name="script">по умолчанию - пустая коллекция
        /// Сценарий 1 - базовая с 5-тью элементами
        /// Сценарий 2 - один элемент совпадающий со Сценарий 1
        /// Сценарий 2 - один новый элемент</param>
        public UserCollection(int script = 0)
            => _ = script switch
            {
                1 => _elements = new Element[]
                {
                    new() {Name = "A", Number = -10},
                    new() {Name = "Aa", Number = 1},
                    new() {Name = "B", Number = 2},
                    new() {Name = "C", Number = 3},
                    new() {Name = "A", Number = 4},
                    new() {Name = "A", Number = 4}
                },
                2 => _elements = new Element[]
                {
                    new() {Name = "B", Number = -10},
                    new() {Name = "J", Number = 55}
                },
                3 => _elements = new Element[]
                {
                    new() {Name = "D", Number = 5}
                },
                _ => _elements = Array.Empty<Element>()
            };

        private UserCollection(IEnumerable<Element> elements) 
            => _elements = elements as Element[] ?? elements.ToArray();

        public static UserCollection Get(IEnumerable<Element> elements)
            => new(elements);
    }
}
