
using System;
using System.Collections.Generic;

namespace Task11Collections
{
    /// <summary>
    /// Тип-компаратор, описывающий логику сравнения элементов в обратном порядке 
    /// </summary>
    class Comparer<T> : IComparer<T> where T : IComparable <T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);

            

        }
    }
}
