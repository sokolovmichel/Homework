using System;
using Task11AbstractFactory;

namespace FurnitureFactory.Office
{
    class OfficeFactory : IFactory
    {
        public OfficeFactory()
        {
            Console.WriteLine("Офисная мебель:");
        }
        public IChair CreateChair()
        {
            return new Chair();
        }

        public ITable CreateTable()
        {
            return new Table();
        }
    }
}
