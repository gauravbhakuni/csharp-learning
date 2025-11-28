using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            byte number = 20;
            int count = 30;
            float price = 48.52f;
            char character = 'a';
            string name = "john";
            bool flag = false;

            //Console.WriteLine("number = " + number);
            //Console.WriteLine("count = " + count);
            //Console.WriteLine("price = " + price);
            //Console.WriteLine("character = " + character);
            //Console.WriteLine("name = " + name);
            //Console.WriteLine("flag = " + flag);

            Console.WriteLine($"{number}, {count}, {price}, {character}, {name}, {flag}");
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", number, count, price, character, name, flag);

            //type conversion
            // integer to byte
            int i = 256;
            byte b = (byte)i;
            Console.WriteLine(b);

            // string to integer
            string s = "123";
            int j = int.Parse(s);
            Console.WriteLine(j);
        }
    }
}