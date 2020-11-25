using System;
using System.Text;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int m;
            int n;
            m = GetData_keyb("значення m кількість стрічок масиву");
            n = GetData_keyb("значення n кількість стрічок масиву");

            int[,] mas = new int[m, n];

            Arr_rand(ref mas);
            Arr_print(mas);

            int key;
            key = GetData_keyb("значення ключа для пошуку", "numb");

            Arr_find(mas, key);

            Arr_func(mas);
            
        }

        public static int GetData_keyb(string s, string mode = "arr")
        {
            int x = 0;
            Console.Write($"\nВведіть {s}: ");
            string str = Console.ReadLine();
            switch (mode)
            {
                case "arr":
                    while (!int.TryParse(str, out x) | x <= 0)
                    {
                        Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                        str = Console.ReadLine();
                    }
                    break;

                case "numb":
                    while (!int.TryParse(str, out x))
                    {
                        Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                        str = Console.ReadLine();
                    }
                    break;
            }
            return x;
        }

        public static void Arr_rand(ref int[,] arr)
        {
            Random rnd = new Random();
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i,j] = rnd.Next(1, 41);
                }
            }
        }

        public static void Arr_print(int[,] arr)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"arr[{i},{j}] = {arr[i, j]}");
                }

                Console.WriteLine();
                
            }
        }

        public static void Arr_find(int[,] arr, int key)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            bool flag = true;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] == key)
                    {
                        Console.WriteLine($"array[{i},{j}] = {arr[i, j]}");
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine($"У масиві немає елемента {key}");
            }
            Console.WriteLine();
        }

        public static void Arr_func(int[,] arr)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            int max;
            int min;
            for (int i = 0; i < m; i++)
            {
                max = arr[i, 0];
                min = arr[i, 0];
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }

                    if (arr[i,j] < min)
                    {
                        min = arr[i, j];
                    }
                }

                Console.WriteLine($"{i+1}. min({min}) + max({max}) = {min + max}");

            }
        }

    }
}
