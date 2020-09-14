using System;
using System.Collections.Generic;

namespace Task11Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //добавление чисел в "дерево" из целочисленного массива, 
            // при этом в "дереве" они хранятся в порядке убывания         
            int[] myArray = { 5, 8, 9, 1, 12, 65, 7, 10 };
            var BT7 = new BinaryTree<int>(myArray, new Comparer<int>());

            // добавляем несколько чисел в дерево
            BT7.Add(4);
            BT7.Add(88);
            BT7.Add(258);

            // вывод чисел «дерева» в том порядке, в котором они храняться в "дереве"
            foreach (int i in BT7)
            {
                Console.WriteLine(i);
            }


            Console.ReadLine();

            // добавление результатов прохождения тестов студентами в "дерево",
            // при этом элементы в "дереве" хранятся в порядке убывания "оценок (баллов)" по тесту
            Student[] students = new Student[]
            {
                                    new Student { StudentName = "Bill", TestScore = 34 },
                                    new Student { StudentName = "Tom", TestScore = 58 },
                                    new Student { StudentName = "Alice", TestScore = 21 },
                                    new Student { StudentName = "Artur", TestScore = 42 },
                                    new Student { StudentName = "Agul", TestScore = 18 },
                                    new Student { StudentName = "John", TestScore = 23 },
                                    new Student { StudentName = "Glen", TestScore = 22 },
                                    new Student { StudentName = "Jane", TestScore = 21 },
                                    new Student { StudentName = "Mike", TestScore = 59 }
            };

            var BT = new BinaryTree<Student>(students);

            foreach (var bt in BT)
            {
                Console.WriteLine(bt.StudentName + " " + bt.TestScore);
            }

            Console.ReadLine();

            // применение созданного "дерева" для хранения строк
            List<string> myString = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
            var BT5 = new BinaryTree<string>();
            for (int i = 0; i < myString.Count; i++)
            {
                BT5.Add(myString[i]);
            }

            // вывод строк в обратном порядке, используя метод "дерева", который возвращает "перечислитель"
            // для прохода "дерева" в обратном порядке.
            foreach (var bt in BT5.ReversedTraversal(BT5.head))
            {
                Console.WriteLine(bt);
            }

          















        }




    }
}
