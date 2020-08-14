using System;
using System.Globalization;

namespace Task5Vector
{
    // класс проверки на корректность введенных пользователем данных
    class CheckInput
    {
        public static IFormatProvider culture = CultureInfo.CurrentCulture;
        
        // проверка на корректность введенных координат (количество и число)
        public static void Convert(string AllText, out double X1, out double Y1, out double Z1)
        {
            bool A, B, C, Amount;
            double X2 = 0;
            double Y2 = 0;
            double Z2 = 0;
            do
            {
                A = B = C = Amount = false;
                char[] Separator = { ' ' };
                string[] Coordinates = AllText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
                var n = Coordinates.Length;

                if (n == 3)
                {
                    Amount = true;
                    A = double.TryParse(Coordinates[0], NumberStyles.AllowDecimalPoint, culture, out X2);
                    B = double.TryParse(Coordinates[1], NumberStyles.AllowDecimalPoint, culture, out Y2);
                    C = double.TryParse(Coordinates[2], NumberStyles.AllowDecimalPoint, culture, out Z2);
                }

                if (!(Amount && A && B && C))
                {
                    Console.WriteLine($"Введены некорректные данные!");
                    Console.Write("Попробуйте еще раз: ");
                    AllText = Console.ReadLine();
                }

            } while (!(Amount && A && B && C));

            X1 = X2;
            Y1 = Y2;
            Z1 = Z2;

        }

        // проверка на корректность введения числа для умножения на вектор
        public static double CheckNumber(string m)
        {
            bool isNumber;
            double M;
            do
            {
                isNumber = double.TryParse(m, NumberStyles.AllowDecimalPoint, culture, out M);
                if (!isNumber)
                {
                    Console.WriteLine($"Введены некорректные данные!");
                    Console.Write("Введите число, на которое будет умножен вектор: ");
                    m = Console.ReadLine();
                }
        
            } while (!isNumber);

            return M;

        }
    }
}
