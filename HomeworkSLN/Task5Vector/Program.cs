using System;


namespace Task5Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите координаты первого трехмерного вектора (через пробел): ");
            CheckInput.Convert(Console.ReadLine(), out double X, out double Y, out double Z);
            Vector a = new Vector(X, Y, Z);
           
            Console.Write("Введите координаты второго трехмерного вектора (через пробел): ");
            CheckInput.Convert(Console.ReadLine(), out X, out Y, out Z);
            Vector b = new Vector(X, Y, Z);

            Console.Write("Введите число, на которое будет умножен вектор: ");
            double M = CheckInput.CheckNumber(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Исходные данные: вектор а{a} и вектор b{b}");
            Console.WriteLine($"Сумма векторов равна: {a + b}");
            Console.WriteLine($"Разница векторов равна: {a - b}");
            Console.WriteLine($"Произведение векторов на число {M} равно: {a * M} и {b * M}");
            Console.WriteLine($"Скалярное произведение векторов равно: {a * b}");
        }

        
    }
}
