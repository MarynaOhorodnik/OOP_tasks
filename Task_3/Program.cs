using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            double b;
            long c;
            while (true)
            {
                try
                {
                    Console.Write("(int) a = ");
                    a = Convert.ToInt32(Console.ReadLine());
                    break;
                }

                catch
                {
                    Console.WriteLine("It is not int. Input again.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("(double) b = ");
                    b = Convert.ToDouble(Console.ReadLine());
                    break;
                }

                catch
                {
                    Console.WriteLine("It is not double. Input again.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("(long) c = ");
                    c = Convert.ToInt64(Console.ReadLine());
                    break;
                }

                catch
                {
                    Console.WriteLine("It is not long. Input again.");
                }
            }

            Console.WriteLine($"a = {a}; b = {b}; c = {c}");
        }
    }
}
