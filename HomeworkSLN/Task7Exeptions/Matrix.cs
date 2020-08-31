using System;


namespace Task7Exeptions
{
    /// <summary>
    /// Предоставляет методы для создания матриц и выполнения с ними различных операций.
    /// </summary>
    public class Matrix 
    {
        public int[,] numbers; // базовый массив
        public int Length;
        public readonly int firstIndex; // первый индекс массива 
        public readonly int secondIndex; // второй индекс массива 

        

        public Matrix(int i, int j)
        {
            numbers = new int[i, j];
            firstIndex = i;
            secondIndex = j;
            Length = j;
        }

        public int this[int i, int j]
        {
            get
            {
                return numbers[i, j];
            }
            set
            {
                numbers[i, j] = value;
            }
        }
        
        //переопределение метода ToString() для формирования строкового представления матрицы
        public override string ToString()
        {
            string myString = "";
            for (int i = 0; i < firstIndex; i++)
            {
                for (int j = 0; j < secondIndex; j++)
                {
                    myString += numbers[i, j].ToString() + " ";
                }
                myString += Environment.NewLine;
            }

            return myString;
        }

        // перегрузка операции сложения
        public static Matrix operator + (Matrix A, Matrix B)
        {
            if (A.firstIndex != B.firstIndex || A.secondIndex != B.secondIndex)
            {
                throw new MatrixException("Сложение не возможно! Размеры матриц не совпадают: ", A.firstIndex, A.secondIndex, B.firstIndex, B.secondIndex);
            }
            
            Matrix C = new Matrix(A.firstIndex, A.secondIndex);
            for (int i = 0; i < A.firstIndex; i++)
            {
                for (int j = 0; j < A.secondIndex; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }

        // перегрузка операции вычитания
        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.firstIndex != B.firstIndex || A.secondIndex != B.secondIndex)
            {
                throw new MatrixException("Вычитание не возможно! Размеры матриц не совпадают: ", A.firstIndex, A.secondIndex, B.firstIndex, B.secondIndex);
            }

            Matrix C = new Matrix(A.firstIndex, A.secondIndex);
            for (int i = 0; i < A.firstIndex; i++)
            {
                for (int j = 0; j < A.secondIndex; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C;
        }

        // перегрузка операции умножения
        public static Matrix operator * (Matrix A, Matrix B)
        {
            if (A.secondIndex != B.firstIndex)
            {
                throw new MatrixException("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы: ", A.secondIndex, B.firstIndex);
            }

            Matrix C = new Matrix(A.firstIndex, B.secondIndex);
            for (int i = 0; i < A.firstIndex; i++)
            {
                for (int j = 0; j < B.secondIndex; j++)
                {
                    for (int k = 0; k < A.secondIndex; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }

        // возвращает нулевую матрицу заданного размера
        public static Matrix GetEmpty (int firstIndex, int secondIndex)
        {
            Matrix C = new Matrix (firstIndex, secondIndex);
            for (int i = 0; i < firstIndex; i++)
            {
                for (int j = 0; j < secondIndex; j++)
                {
                    C[i, j] = 0;
                }
            }
            return C;
        }
    }
}
