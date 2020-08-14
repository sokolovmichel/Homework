using System;


namespace Task4Triangle
{
    /// <summary>
    /// Класс Triangle реализует функции подсчета площади и периметра треугольника по заданным длинам сторон 
    /// </summary>
    public class Triangle
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        /// <summary>
        /// Длины сторон треугольника
        /// </summary>
        
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        /// <summary>
        /// Вычисление площади треугольника по формуле Герона.<br/>
        /// Площадь равна корню из произведения разностей полупериметра треугольника и каждой из его сторон.
        /// </summary>

        public double CalculateArea() 
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt((s * (s - a) * (s - b) * (s - c)));
        }

        /// <summary>
        /// Вычисление периметра треугольника.<br/>Периметр равен сумме длин сторон треугольника.
        /// </summary>
        /// <returns></returns>
        public double CalculatePerimeter()
        {
            return a + b + c;
        }
    }
}
