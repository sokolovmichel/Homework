namespace FurnitureFactory
{
    interface IFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
}
