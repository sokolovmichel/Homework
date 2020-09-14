using System;


namespace Task11Collections
{
    /// <summary>
    /// Узел двоичного дерева
    /// </summary>
    /// <typeparam name="T">Произвольный тип данных</typeparam>
    class BinaryTreeNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// Значение узла
        /// </summary>
        public T Value { get; private set; }
        /// <summary>
        /// Ссылка на левую ветку
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }
        /// <summary>
        /// Ссылка на правую ветку
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }
        /// <summary>
        /// Сравнивает узлы
        /// </summary>
        /// <param name="value">Сравниваемое значение</param>
        /// <returns>Возвращает 1, если значение текущего узла больше,
        /// чем переданного методу, -1, если меньше и 0, если они равны</returns>
        public int CompareTo(T value)
        {
            return Value.CompareTo(value);
        }
    }
}
