using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3CommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
             
            
            
            Console.WriteLine("Введите числа через пробел: ");

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int r = GreatestCommonDivisor.CalculateGCD(list);


            Console.WriteLine($"Наибольший общий делитель равен: {r}");
           
        }

    }
    /// <summary>
    /// Реализация алгоритма Евклида для вычисления наибольшего общего делителя
    /// </summary>
    public class GreatestCommonDivisor
    {
        /// <summary>
        /// метод вычисления НОД для массива целых чисел
        /// </summary>
        public static int CalculateGCD(List<int> val)
        {
            int result = 0;

            for (int i = 0; i < val.Capacity - 1; i++)
            {
                while (val[i] != val[i + 1])
                {
                    if (val[i] > val[i + 1]) val[i] = val[i] - val[i + 1];
                    else val[i + 1] = val[i + 1] - val[i];

                }

                result = val[i];
            }


            return result;
        }

        
        // метод вычисления НОД для двух целых чисел
        
        //public static int CalculateGCD(int a, int b) 
        //{
        //    while (a != b)
        //    {
        //        if (a > b) a = a - b;
        //        else b = b - a;
        //    }
        //    return a;
        //}

        
        // метод вычисления НОД для трех целых чисел
        
        //public static int CalculateGCD(int a, int b, int c)
        //{
        //    while (a != b)
        //    {
        //        if (a > b) a = a - b;
        //        else b = b - a;
        //    }
        //    while (a != c)
        //    {
        //        if (a > c) a = a - c;
        //        else c = c - a;
        //    }
        //    return a;
        //}



    }
}
