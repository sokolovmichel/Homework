using System;

namespace _1_Performance_Profiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "a";
            while (true)
            {
                myString += myString;
                Console.WriteLine(myString.Length);
            }
            
        }
    }
}
