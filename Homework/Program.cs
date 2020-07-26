using System;
using System.Globalization;

namespace FormattingCoordinates
{

    public class Program
    {
        static void Main(string[] args)
        {
            string s = ReadData.Read();
            ReadData.Convert(s);
            Console.Read();
        }
    }

    public class ReadData
    {
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

        public static string Convert (string AllText)
        {
            Decimal[] X, Y;
            //var AllText = String.Empty;
            string Text = String.Empty;

            Char[] Separator = { '\t', '\r', '\n', ' ', ',' };

            var Coordinates = AllText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var n = Coordinates.Length;
            var z = n % 2;
            if (z != 0)
            {
                Console.WriteLine("Количество исходных данных не кратно двум");
                Console.Read();
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

                Text += String.Format("X:{0}" + "Y:{1}" ,
                    X[i], Y[i]);

            }

            return Text;
            Console.ReadLine();

        }


    }
}
