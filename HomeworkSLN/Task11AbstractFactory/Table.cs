using System;
using FurnitureFactory;


namespace Task11AbstractFactory
{
    class Table : ITable
    {
        public Table()
        {
            Console.WriteLine("Стол");
        }
    }
}