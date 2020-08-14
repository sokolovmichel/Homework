

namespace Task5Vector
{
    public class Vector
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

            
        public Vector(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        // переопределение метода для формирования строкого представления «вектора»
        public override string ToString()
        {
            return $"({X};{Y};{Z})";
        }
        // перегрузка операции сложения
        public static Vector operator + (Vector a, Vector b)
        {
            double X = a.X + b.X;
            double Y = a.Y + b.Y;
            double Z = a.Z + b.Z;
            return new Vector(X, Y, Z);  
        }
        // перегрузка операции вычитания
        public static Vector operator -(Vector a, Vector b)
        {
            double X = a.X - b.X;
            double Y = a.Y - b.Y;
            double Z = a.Z - b.Z;
            return new Vector(X, Y, Z);
        }
        // перегрузка операции умножения на произвольное число
        public static Vector operator *(Vector a, double M)
        {
            double X = a.X * M;
            double Y = a.Y * M;
            double Z = a.Z * M;
            return new Vector(X, Y, Z);
        }
        
        // перегрузка операции умножения - скалярное произведение векторов
        public static double operator *(Vector a, Vector b)
        {
           return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
    }
}
