using System;
using Homework;


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

    
}
