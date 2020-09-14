using FurnitureFactory;


namespace Task11AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Furniture myFurniture = new Furniture();
            IFactory factory = new FurnitureFactory.Wicker.WickerFactory();
            myFurniture.CreateFurniture(factory);

            System.Console.WriteLine();

            factory = new FurnitureFactory.Office.OfficeFactory();
            myFurniture.CreateFurniture(factory);




            //IFactory factory = new FurnitureFactory.Wicker.WickerFactory();
            //ITable table = factory.CreateTable();

        }
    }
}
