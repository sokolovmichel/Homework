using System;
using System.Linq;


namespace Task7Exeptions
{
    /// <summary>
    /// Проверяет корректность ввода данных
    /// </summary>
    class CheckInput
    {
        /// <summary>
        /// Проверяет ввод на отсутствие данных.<br/>
        /// В случае отсутствия данных, информирует об ошибке<br/>
        /// и предлагает повторить ввод.
        /// </summary>
        public static string CheckForNull()
        {
            string AllText;
            do
            {
                AllText = Console.ReadLine();
                if (string.IsNullOrEmpty(AllText))
                {
                    Console.WriteLine($"Данные не введены!");
                    Console.WriteLine("Попробуйте еще раз: ");
                }
            } while (string.IsNullOrEmpty(AllText));
            return AllText;
        }
        /// <summary>
        /// Преобразует строку значений в массив типа int.<br/>
        /// В случае не числового ввода, информирует об ошибке<br/>
        /// и предлагает повторить ввод.
        /// </summary>
        /// <param name="AllText">Строка значений</param>
        /// <param name="isWhiteSpace">Если в конце строки введен пробел - значение true</param>
        /// <returns></returns>
        public static Matrix Convert(string AllText, out bool isWhiteSpace)
        {
            bool[] A; // массив для хранения проверок условия числового ввода
            Matrix X2; // массив для вывода преобразованных и проверенных значений
            int n; // длина строкового массива

            do
            {
                char[] Separator = { ' ' };
                string[] Coordinates = AllText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
                n = Coordinates.Length;
                A = new bool [n];
                X2 = new Matrix (1, n);

                // проверяет каждое значение из строкового массива Coordinates,
                // результат записывает в boolean-массив A,
                // в случае успешного преобразования полученное значение p записываетв массив X2
                for (int i = 0; i < n; i++)
                {
                    A[i] = int.TryParse(Coordinates[i], out int p);
                    X2[0, i] = p;
                }
                
                // если массив А содержит значение false, то выводится соотвествующее сообщение
                if (A.Contains(false))
                {
                    Console.WriteLine($"Введены некорректные данные!");
                    Console.WriteLine("Попробуйте еще раз: ");
                    AllText = Console.ReadLine();
                }

               

            } while (A.Contains(false));

            // проверяет введен ли в конце строки пробел для указания необходимости ввода следующей строки в матрицу
            bool space = false;
            if (AllText.EndsWith(" "))
            {
                space = true;
            }

            isWhiteSpace = space;
            return X2;
            
        }

        
    }
}
