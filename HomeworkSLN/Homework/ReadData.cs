using System;
using System.Globalization;

namespace Homework
{

    /// <summary>
    /// Класс читает координаты из перенаправленного файла и выводит их
    /// в отформатированной виде на консоль
    /// </summary>
    public class ReadData
    {
        /// <summary>
        /// метод читает читает координаты из перенаправленного файла
        /// и выводит их в строковую переменную
        /// </summary>
        /// <returns></returns>
        public static string Read()
        {
            var AllText = string.Empty;

            try
            {
                string line = string.Empty;
                do
                {
                    line = Console.ReadLine();
                    AllText += line + ",";

                } while (!string.IsNullOrWhiteSpace(line));

                return AllText;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;

        }

        /// <summary>
        /// метод форматирует исходные координаты, полученные из строковой переменной
        /// и выводит их на консоль
        /// </summary>

        public static string Convert(string AllText)
        {
            decimal[] X, Y;

            string Text = string.Empty;

            char[] Separator = { '\t', '\r', '\n', ' ', ',' };

            var Coordinates = AllText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var n = Coordinates.Length;
            var z = n % 2;
            if (z != 0)
            {
                Console.WriteLine("Количество исходных данных не кратно двум");

                return null;
            }

            X = new decimal[n / 2];
            Y = new decimal[n / 2];

            bool A, B;
            var j = 0;


            for (var i = 0; i <= n / 2 - 1; i++)
            {
                IFormatProvider culture = new CultureInfo("en-Us", useUserOverride: true);
                A = decimal.TryParse(Coordinates[j], NumberStyles.AllowDecimalPoint, culture, out X[i]);
                j = j + 1;
                B = decimal.TryParse(Coordinates[j], NumberStyles.AllowDecimalPoint, culture, out Y[i]);
                j = j + 1;

                if ((A && B) == false)
                    Console.WriteLine(string.Format("В строке {0} - не числовой ввод!", i + 1));
            }

            for (var i = 0; i <= n / 2 - 1; i++)
            {
                IFormatProvider culture = CultureInfo.CurrentCulture;
                Console.Write(string.Format(culture, "X: {0,-7} " + "Y: {1,-7}" + "\n",
                    X[i], Y[i]));

                Text = string.Format("X: {0}" + "Y: {1}", X[i], Y[i]);

            }

            return Text;

        }
    }
}
