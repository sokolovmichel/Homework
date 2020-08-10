using System;


namespace Task4Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длины сторон треугольника:");

            Check.CheckTriangle(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), out double a, out double b, out double c);           
                        
            Triangle myTriangle = new Triangle(a, b, c);
            
            Console.Write("Площадь треугольника равна: ");
            Console.WriteLine($"{myTriangle.CalculateArea():F}");
            Console.Write($"Периметр треугольника равен: ");
            Console.WriteLine($"{myTriangle.CalculatePerimeter():F}");
        }
    }
}
