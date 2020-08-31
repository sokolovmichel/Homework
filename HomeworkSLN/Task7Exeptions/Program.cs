using System;


namespace Task7Exeptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ПРАВИЛА ВВОДА ЗНАЧЕНИЙ МАТРИЦЫ:" +
                "\n1. Значения в строке вводить через пробел" +
                "\n2. Для перехода к вводу значений следующей строки введите пробел и нажмите ENTER" +
                "\n3. Следите за равенством количества значений в различных строках" +
                "\n4. При окончании ввода матрицы нажмите ENTER после ввода последнего значения\n");

            Console.WriteLine("Введите значения первой матрицы:");
            Matrix A = InputValues();

            Console.WriteLine();
            
            Console.WriteLine("Введите значения второй матрицы:");
            Matrix B = InputValues();

            
            Console.WriteLine();
            try
            {
                Console.WriteLine("Результат сложения матриц: ");
                Console.Write(A + B);
            }
            catch (MatrixException ex)
                {
                    Console.Write(ex.Message);
                    Console.WriteLine($"{ex.firstIndexA}x{ex.secondIndexA} и {ex.firstIndexB}x{ex.secondIndexB}");
                }


                Console.WriteLine();
            try
                {
                    Console.WriteLine("Результат вычитания матриц: ");
                    Console.Write(A - B);
                }
            catch (MatrixException ex)
                {
                    Console.Write(ex.Message);
                    Console.WriteLine($"{ex.firstIndexA}x{ex.secondIndexA} и {ex.firstIndexB}x{ex.secondIndexB}");
                }

                Console.WriteLine();
            try
                {
                    Console.WriteLine("Результат умножения матриц: ");
                    Console.Write(A * B);
                }
            catch (MatrixException ex)
                {
                    Console.Write(ex.Message);
                    Console.WriteLine($"{ex.secondIndexA} и {ex.firstIndexB}");
                }
            
            

        }

        /// <summary>
        /// <b>Обеспечивает ввод данных в матрицу из консольной строки с произвольным количеством строк и столбцов.</b><br/>
        /// Значения в строке разделяются пробелами.<br/>
        /// Для ввода следующей строки после последнего значения необходимо нажать пробел и ENTER.<br/>
        /// Для окончание ввода данных после последнего значения необходимо нажать ENTER.
        /// </summary>
        static Matrix InputValues() 
        {
            string AllText = CheckInput.CheckForNull(); //проверяет на ввод пустой строки (нулевой ввод)
            
            Matrix array = CheckInput.Convert(AllText, out bool isWhiteSpace); //конвертирует строковые значения в массив int
            int n = array.Length;
            Matrix temp = new Matrix(1, n);
            

            for (int i = 0; i < n; i++)
            {
                temp[0, i] = array[0, i];
            }

            if (!isWhiteSpace)
            {
                return temp;
            }

            int a = 2;

            while (true)
            {

                Matrix array1;
                bool isWhiteSpace1;
                do
                {
                    AllText = CheckInput.CheckForNull();
                    array1 = CheckInput.Convert(AllText, out isWhiteSpace1);
                    if (array1.Length != n)
                    {
                        Console.WriteLine("Количество столбцов не совпадает.\nПовторите ввод!");
                    }
                } while (array1.Length != n);


                Matrix array2 = new Matrix(a, n);
                
                for (int i = 0; i < a - 1; i++)
                    for (int j = 0; j < n; j++)
                    {
                        array2[i, j] = temp[i, j];
                        array2[a - 1, j] = array1[0, j];
                    }

                if (isWhiteSpace1)
                {
                    a++;
                    temp = array2;
                }
                else
                {
                    temp = array2;
                    break;
                }
            }
                        
            return temp;

            



        }
        
    }
}
