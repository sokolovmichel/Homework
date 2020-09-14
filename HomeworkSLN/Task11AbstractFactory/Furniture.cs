using System;


namespace FurnitureFactory
{
    class Furniture
    {
        IChair a; 
        ITable b; 

        
        public void CreateFurniture (IFactory factory) 
        {
            a = factory.CreateChair();
            b = factory.CreateTable();
        }
    }
}
