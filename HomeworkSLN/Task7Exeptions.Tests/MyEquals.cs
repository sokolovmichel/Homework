
namespace Task7Exeptions.Tests
{
    class MyEquals
    {
        static string str = string.Empty;

        /// <summary>
        /// Сравнивает между собой элементы двух объектов Matrix, в случае равенства выдает значение true
        /// </summary>
        /// <param name="A">Первый объект Matrix</param>
        /// <param name="B">Второй объект Matrix</param>
        /// <returns></returns>
        public static bool Equals (Matrix A, Matrix B)
        {
           for (int i = 0; i < A.firstIndex; i++)
           {
                for (int j = 0; j < A.secondIndex; j++)
                {
                    if (A[i, j] != B[i, j])
                    {
                        str += "false" + " ";
                    }
                }
            }

           if (str.Contains("false"))
            {
                return false;
            }
            return true;
        }
    }
}
