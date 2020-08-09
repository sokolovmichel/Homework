using System;

namespace _2_Newton_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите подкоренное число: ");
            double A = Double.Parse(Console.ReadLine()); //число из которого извлекаем корень
            Console.WriteLine("Введите показатель корня: ");
            int n = int.Parse(Console.ReadLine()); //показатель степени
            Console.WriteLine("Введите требуемую точность (от 1 до 20): ");
            int t = int.Parse(Console.ReadLine()); //точность
            Console.WriteLine();

            Console.WriteLine($"{NewtonRoot(A, n, t)} - значение корня, рассчитанное методом Ньютона с точностью {t}.");
            Console.WriteLine($"{Math.Pow(A, (double)1 / n)} - значение корня, рассчитанное с помощью метода Math.Pow().");
            

        }

        static double NewtonRoot(double A, int n, int t)
        {
            double d = 0; //дельта

            double[] x = new double[20];
            x[0] = A;
            int i = 0;
            do 
            {
                x[i + 1] = x[i] * (1 - (1 - A / Math.Pow(x[i], n)) / n);
                d = x[i] - x[i + 1];
                i++;

            } while (d > Math.Pow(10, -t));

            return x[i - 1];

        }

    }
}
