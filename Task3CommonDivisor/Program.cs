using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Task3CommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());

            //int a = 1068; int b = 3096; int c = 11184; int d = 31068; int e = 660;

            TimeSpan value;
            TimeSpan value2;
            int r = GreatestCommonDivisor.CalculateEuclideanGCD(a, b, out value);
            int r2 = GreatestCommonDivisor.CalculateSteinGCD(a, b, out value2);

            ////ввод данных для произвольного количества чисел
            //Console.WriteLine("Введите числа через пробел: ");
            //List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            //int r = GreatestCommonDivisor.CalculateGCD(list);

            Console.WriteLine();
            Console.WriteLine($"Наибольший общий делитель (по алгоритму Евклида) равен: {r}, время вычисления: {value:s\\.fffffff} сек.");
            Console.WriteLine($"Наибольший общий делитель (по алгоритму Стейна) равен: {r2}, время вычисления: {value2:s\\.fffffff} сек.");

        }

    }
    /// <summary>
    /// Класс реализации алгоритмов для вычисления наибольшего общего делителя целых чисел
    /// </summary>
    public class GreatestCommonDivisor
    {
        /// <summary>
        /// метод вычисления НОД для двух целых чисел по алгоритму Евклида
        /// </summary>
        
        public static int CalculateEuclideanGCD(int a, int b)
        {
            
            while (a != b)
            {
                if (a > b) a = a - b;
                else b = b - a;
            }
                        
            return a;
        }

        /// <summary>
        /// Обертка для метода вычисления НОД по алгоритму Евклида,
        /// содержащая значение времени, необходимое для выполнения расчетов.
        /// </summary>

        public static int CalculateEuclideanGCD(int a, int b, out TimeSpan ts)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int t = CalculateEuclideanGCD(a, b);

            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            return t;
        }



        /// <summary>
        /// метод вычисления НОД для трех целых чисел по алгоритму Евклида
        /// </summary>


        public static int CalculateEuclideanGCD(int a, int b, int c)
        {
            while (a != b)
            {
                if (a > b) a = a - b;
                else b = b - a;
            }
            while (a != c)
            {
                if (a > c) a = a - c;
                else c = c - a;
            }
            return a;
        }

        /// <summary>
        /// метод вычисления НОД для пяти целых чисел по алгоритму Евклида
        /// </summary>
        public static int CalculateEuclideanGCD(int a, int b, int c, int d, int e)
        {
            int[] val = {a, b, c, d, e };
            
            int i;
            for (i = 0; i < val.Length - 1; i++)
            {
                while (val[i] != val[i + 1])
                {
                    if (val[i] > val[i + 1]) val[i] = val[i] - val[i + 1];
                    else val[i + 1] = val[i + 1] - val[i];

                }

            }

            return val[i];
        }

        /// <summary>
        /// метод вычисления НОД для двух целых чисел по алгоритму Стейна
        /// </summary>
       
        public static int CalculateSteinGCD(int a, int b)
        {
            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a; 
            if ((a & 1) == 0)
                {
                if ((b & 1) == 1) return CalculateSteinGCD(a >> 1, b);
                else  return CalculateSteinGCD(a >> 1, b >> 1) << 1; 
                }
            if ((b & 1) == 0) return CalculateSteinGCD(a, b >> 1);
            if (a > b) return CalculateSteinGCD((a - b) >> 1, b);
            return CalculateSteinGCD((b - a) >> 1, a);
                     
        }

        /// <summary>
        /// Обертка для метода вычисления НОД по алгоритму Стейна,
        /// содержащая значение времени, необходимое для выполнения расчетов.
        /// </summary>
        
        public static int CalculateSteinGCD(int a, int b, out TimeSpan ts)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
           
            int t = CalculateSteinGCD(a, b);

            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            return t;
            
        }



    }
}
