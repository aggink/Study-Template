using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    public class MySet<T>
    {
        private readonly List<T> items;

        /// <summary>
        /// Геттер числа элементов
        /// </summary>
        public int Count()
        {
            return items.Count;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public MySet(List<T> collection)
        {

            items = new List<T>();

            foreach (T i in collection)
            {
                if (!items.Contains(i))
                {
                    items.Add(i);
                }
            }
        }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        public override string ToString()
        {
            string result = "{";

            for (int i = 0; i < items.Count; i++)
            {
                result += items[i];

                if (i < items.Count - 1)
                    result += ", ";
            }

            result += "}";
            return result;
        }

        /// <summary>
        /// Перегрузка оператора | (Объединение)
        /// </summary>
        public static MySet<T> operator |(MySet<T> a, MySet<T> b)
        {
            List<T> result = new List<T>();

            foreach (T i in a.items)
            {
                if (!result.Contains(i))
                    result.Add(i);
            }

            foreach (T i in b.items)
            {
                if (!result.Contains(i))
                    result.Add(i);
            }

            return new MySet<T>(result);
        }

        /// <summary>
        /// Перегрузка оператора - (Разность)
        /// </summary>
        public static MySet<T> operator -(MySet<T> a, MySet<T> b)
        {
            List<T> result = new List<T>();

            foreach (T i in a.items)
            {
                if (!b.items.Contains(i))
                    result.Add(i);
            }

            return new MySet<T>(result);
        }

        /// <summary>
        /// Перегрузка оператора & (Пересечение)
        /// </summary>
        public static MySet<T> operator &(MySet<T> a, MySet<T> b)
        {
            List<T> result = new List<T>();

            foreach (T i in a.items)
            {
                if (b.items.Contains(i))
                    result.Add(i);
            }

            return new MySet<T>(result);
        }

        /// <summary>
        /// Перегрузка оператора / (Симметрическая разность)
        /// </summary>
        public static MySet<T> operator /(MySet<T> a, MySet<T> b)
        {
            return (a - b) | (b - a);
        }

        /// <summary>
        /// Перегрузка оператора == (Равенство)
        /// </summary>
        public static bool operator ==(MySet<T> a, MySet<T> b)
        {

            if ((object)a == null || (object)b == null)
                return false;

            if (a.Count() != b.Count())
                return false;

            foreach (T i in a.items)
            {
                if (!b.items.Contains(i))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Перегрузка оператора != (Неравенство)
        /// </summary>
        public static bool operator !=(MySet<T> a, MySet<T> b)
        {
            return !(a == b);
        }
    }
}
