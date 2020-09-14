using System;
using Task11AbstractFactory;

namespace FurnitureFactory.Wicker
{
    class WickerFactory : IFactory
    {
        public WickerFactory()
        {
            Console.WriteLine("Плетеная мебель: ");
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
