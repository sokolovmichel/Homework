using System;
using System.Globalization;

namespace Task4Triangle
{
    /// <summary>
    /// Класс Check проверяет корректность ввода данных и не позволяет создать объект в ошибочном состоянии
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Проверка корректности ввода данных и преобразование данных из строки в числовое значение
        /// </summary>
        
        public static void CheckTriangle(string a1, string b1, string c1, out double A, out double B, out double C)
        {
            bool isNumberA = double.TryParse(a1, NumberStyles.Number, NumberFormatInfo.CurrentInfo, out double a);
            bool isNumberB = double.TryParse(b1, NumberStyles.Number, NumberFormatInfo.CurrentInfo, out double b);
            bool isNumberC = double.TryParse(c1, NumberStyles.Number, NumberFormatInfo.CurrentInfo, out double c);
            if (!(isNumberA && isNumberB && isNumberC))
            {
                Console.WriteLine("Ошибка: не числовой ввод.");
                Environment.Exit(0);
            }

            if ((a <= 0) || (b <= 0) || (c <= 0))
            {
                Console.WriteLine("Ошибка: длина стороны треугольника не может быть меньше либо равна 0.");
                Environment.Exit(0);
            }

            if ((a >= (b + c)) || (b >= (a + c)) || (c >= (a + b)))
            {
                Console.WriteLine("Ошибка: сумма длин любых двух сторон треугольника не может быть меньше (либо равна) длины третьей.");
                Environment.Exit(0);
            }
            A = a; B = b; C = c;

            Console.WriteLine("Треугольник создан!") ;
        }
    }
}
