using System;


namespace Task11Collections
{
    class Student : IComparable<Student>
    {
        public string StudentName { get; set; }
        public string TestName { get; set; }
        public DateTime Testdate { get; set; }
        public int TestScore { get; set; }

        /// <summary>
        /// Сравнивает значения для их хранения в порядке убывания
        /// </summary>
        public int CompareTo(Student x)
        {
            if (TestScore > x.TestScore)
                return -1; // было 1
            else if (TestScore < x.TestScore)
                return 1; // было -1
            else
                return 0;

        }
    }
}
