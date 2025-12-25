using System;

namespace BasicInterface
{
    interface Basic
    {
        void Sum(int a, int b);
        void Diff(int a, int b);
    }
    class Program : Basic
    {
        public static void Main(string[] args)
        {
            string greet = "hello world";
            Console.WriteLine(greet);

            Basic b = new Program();
            b.Sum(2, 3);
            b.Diff(2, 3);
        }

        public void Sum(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        public void Diff(int a, int b)
        {
            Console.WriteLine(a-b);
        }
    }
}