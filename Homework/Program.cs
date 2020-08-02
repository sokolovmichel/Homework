using System;
using System.Globalization;

namespace FormattingCoordinates
{
    /// <summary>
    /// Точка входа
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            string s = ReadData.Read();
            ReadData.Convert(s);
            Console.Read();
        }
    }

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
            if (!Console.IsInputRedirected)
            {
                 Console.WriteLine("Эта программа требует, чтобы ввод был перенаправлен из файла.");
                Console.Read();
            }

            Decimal[] X, Y;
            var AllText = String.Empty;

            try
            {
                string line;



                while ((line = Console.ReadLine()) != null)
                {
                    AllText += line + ",";
                }



            }
            catch (System.IO.FileNotFoundException Situation)
            {
                Console.WriteLine("Нет такого файла. " + Situation.Message);
            }
            catch (Exception Situation)
            {
                Console.WriteLine(Situation.Message);
            }

            return AllText;
                        
        }

        /// <summary>
        /// метод форматирует исходные координаты, полученные из строковой переменной
        /// и выводит их на консоль
        /// </summary>

        public static string Convert(string AllText)
        {
            Decimal[] X, Y;

            string Text = String.Empty;

            Char[] Separator = { '\t', '\r', '\n', ' ', ',' };

            var Coordinates = AllText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var n = Coordinates.Length;
            var z = n % 2;
            if (z != 0)
            {
                Console.WriteLine("Количество исходных данных не кратно двум");
                
                return null;
            }



            X = new Decimal[n / 2]; Y = new Decimal[n / 2];

            Boolean A, B;
            var j = 0;

            for (var i = 0; i <= n / 2 - 1; i++)
            {

                IFormatProvider culture = new CultureInfo("en-Us", useUserOverride: true);
                A = Decimal.TryParse(Coordinates[j], NumberStyles.AllowDecimalPoint, culture, out X[i]);
                j = j + 1;
                B = Decimal.TryParse(Coordinates[j], NumberStyles.AllowDecimalPoint, culture, out Y[i]);
                j = j + 1;

                if ((A && B) == false)
                    Console.WriteLine(String.Format("В строке {0} - не числовой ввод!", i + 1));

            }

            for (var i = 0; i <= n / 2 - 1; i++)
            {
                Console.Write(String.Format("X: {0,-7} " + "Y: {1,-7}" + "\n",
                    X[i], Y[i]));

                Text = String.Format("X: {0}" + "Y: {1}",
                    X[i], Y[i]);

                 

            }

            return Text;
            

        }


    }
}
