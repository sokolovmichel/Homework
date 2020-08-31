using System;


namespace Task7Exeptions
{
    class MatrixException : Exception
    {
        public int firstIndexA;
        public int firstIndexB;
        public int secondIndexA;
        public int secondIndexB;

        public MatrixException(string message, int fia, int sia, int fib, int sib) : base (message)
        {
            firstIndexA = fia;
            secondIndexA = sia;
            firstIndexB = fib;
            secondIndexB = sib;
        }
        public MatrixException(string message, int sia, int fib) : base(message)
        {
            secondIndexA = sia;
            firstIndexB = fib;
        }

    }
}
