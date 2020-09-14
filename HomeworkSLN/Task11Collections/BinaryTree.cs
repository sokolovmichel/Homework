using System;
using System.Collections;
using System.Collections.Generic;


namespace Task11Collections
{
    /// <summary>
    /// Двоичное дерево
    /// </summary>
    /// <typeparam name="T">Произвольный тип данных</typeparam>
    class BinaryTree<T>: IEnumerable<T>   where T : IComparable<T>
    {
        public BinaryTreeNode<T> head; // корень
                
        private T[] items; // массив значений для конструктора, принимающего IEnumerable<T>

        IComparer<T> SC;
        private bool isComparer;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BinaryTree()
        {
            
            isComparer = false;

        }
        /// <summary>
        /// Конструктор принимает объект стандартного обобщённого типа для сравнения двух объектов одного типа,
        /// и применяет его для сравнения добавляемых в дерево элементов
        /// </summary>
        /// <param name="sc">Объект, реализующий интрефейс IComparer</param>
        public BinaryTree(IComparer<T> sc)
        {
            SC = sc;
            isComparer = true;
            
        }
       
        /// <summary>
        /// Конструктор принимает объект типа стандартной обобщенной коллекции,
        /// и добавляет элементы коллекции в дерево 
        /// </summary>
        public BinaryTree(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            items = (T[])collection;
            Array.Sort(items);

            for (int i = 0; i < items.Length; i++)
            {
                Add(items[i]);
            }
            isComparer = false;

        }

        /// <summary>
        /// Конструктор принимает и коллекцию элементов для добавления в дерево,
        /// и объект с помощью, которого будет выполнять сравнения.
        /// </summary>
        /// <param name="collection">Тип стандартной обобщенной коллекции IEnumerable<T></param>
        /// <param name="sc">Объект, реализующий интрефейс IComparer</param>
        public BinaryTree(IEnumerable<T> collection, IComparer<T> sc)
        {
                      
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            items = (T[])collection;
            Array.Sort(items, sc);

            for (int i = 0; i < items.Length; i++)
            {
                Add(items[i]);
            }
            isComparer = false;

        }

        /// <summary>
        /// Добавляет элемент в дерево
        /// </summary>
        /// <param name="value">Значение элемента</param>
        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException();

            if (head == null)
            {
                head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(head, value);
            }
            
        }
        /// <summary>
        /// Рекурсивная вставка элемента в дерево
        /// </summary>
        /// <param name="node">Текущее значение элемента в дереве</param>
        /// <param name="value">Новый элемент вставляемый в дерево</param>
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (value == null) throw new ArgumentNullException();
            // в зависимости от того какой конструктор применен для типа,
            // использующий IComparer или IComparable, по разному сравниваются 
            // элементы для добавления в дерево:
            int i;
            if (isComparer) i = SC.Compare(value, node.Value);
            else i = value.CompareTo(node.Value);

            if (i < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        /// <summary>
        /// Возвращает true если значение содержится в дереве. В противном случает возвращает false
        /// </summary>
        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }
        /// <summary>
        /// Находит и возвращает первый узел с заданным значением. 
        /// </summary>
        /// <returns>Возвращает null, если значение не найдено. Также возвращает родителя найденного узла.</returns>
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            
            BinaryTreeNode<T> current = head;
            parent = null;

            
            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    // Если искомое значение меньше, идем налево.
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // Если искомое значение больше, идем направо.
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // Если равны, то останавливаемся
                    break;
                }
            }

            return current;
        }

        /// <summary>
        /// Удаляет первый узел с заданным значением.
        /// </summary>
        /// <param name="value">Значение элемента</param>
        /// <returns>Возвращает true если удаление прошло успешно и false если нет (элемент не содержится в дереве)</returns>
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;

            // Находим удаляемый узел.
            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            

            // Случай 1: Если нет детей справа, левый ребенок встает на место удаляемого.
            if (current.Right == null)
            {
                if (parent == null)
                {
                    head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение родителя больше текущего,
                        // левый ребенок текущего узла становится левым ребенком родителя.
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    { 
                         // Если значение родителя меньше текущего, 
                         // левый ребенок текущего узла становится правым ребенком родителя. 
                        parent.Right = current.Left; 
                    } 
                }
            } 
            
            // Случай 2: Если у правого ребенка нет детей слева 
            // то он занимает место удаляемого узла. 
            else if (current.Right.Left == null) 
            { 
                current.Right.Left = current.Left; 
                if (parent == null) 
                {
                    head = current.Right; 
                }
                else 
                { 
                    int result = parent.CompareTo(current.Value); 
                        if (result > 0)
                        {
                            // Если значение родителя больше текущего,
                            // правый ребенок текущего узла становится левым ребенком родителя.
                            parent.Left = current.Right;
                        }
                        else if (result < 0)
                        { 
                            // Если значение родителя меньше текущего, 
                            // правый ребенок текущего узла становится правым ребенком родителя.
                            parent.Right = current.Right; 
                        } 
                } 
            } 
            
            // Случай 3: Если у правого ребенка есть дети слева, крайний левый ребенок // из правого поддерева заменяет удаляемый узел.
            else 
            { 
                // Найдем крайний левый узел. 
                            BinaryTreeNode<T> leftmost = current.Right.Left; 
                            BinaryTreeNode<T> leftmostParent = current.Right; 
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost; 
                    leftmost = leftmost.Left; 
                } 
                // Левое поддерево родителя становится правым поддеревом крайнего левого узла. 
                leftmostParent.Left = leftmost.Right; 
                // Левый и правый ребенок текущего узла становится левым и правым ребенком крайнего левого.
                leftmost.Left = current.Left; leftmost.Right = current.Right;
                if (parent == null) 
                { 
                    head = leftmost;
                }
                else
                { 
                    int result = parent.CompareTo(current.Value);
                            if (result > 0)
                            {
                                // Если значение родителя больше текущего,
                                // крайний левый узел становится левым ребенком родителя.
                                parent.Left = leftmost;
                            }
                            else if (result < 0)
                            {
                                // Если значение родителя меньше текущего,
                                // крайний левый узел становится правым ребенком родителя.
                                parent.Right = leftmost;
                            }
                }
            }

                    return true;
        }

            
      
        /// <summary>
        /// Возвращает итератор для прохода по дереву в прямом порядке
        /// </summary>
        public IEnumerable<T> Traversal(BinaryTreeNode<T> node)
        {
            
            if (node == null) yield break;

            yield return node.Value;
            foreach (var l in Traversal(node.Left)) yield return l;
            foreach (var r in Traversal(node.Right)) yield return r;

        }
        /// <summary>
        /// Возвращает итератор для прохода по дереву в обратном порядке
        /// </summary>
        public IEnumerable<T> ReversedTraversal(BinaryTreeNode<T> node)
        {
            
            if (node == null) yield break;

            foreach (var l in ReversedTraversal(node.Left)) yield return l;
            yield return node.Value;
            foreach (var r in ReversedTraversal(node.Right)) yield return r;
            
         
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Traversal(head).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




        /// <summary>
        /// Выводит в консоль все значения дерева
        /// </summary>
        public void PrintTree()
        {
            PrintTree(head);
        }
        public void PrintTree(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                
                PrintTree(current.Left);
                Console.WriteLine(current.Value);
                
                PrintTree(current.Right);

            }
            
        }

       
    }
}
