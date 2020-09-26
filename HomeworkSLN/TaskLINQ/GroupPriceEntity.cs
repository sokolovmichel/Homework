using Task.Data;

namespace Task
{
    internal class GroupPriceEntity
    {
        /// <summary>
        ///     Продукт
        /// </summary>
        public Product product { get; set; }

        /// <summary>
        ///     Группа продукта
        /// </summary>
        public int Group { get; set; }
    }
}