using System;
using System.IO;
using System.Text;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            string path_x = @"x.txt";

            double[] array_x = Read_File(path_x);

            Console.WriteLine("Масив x :");
            Array_print(array_x);

            string path_y = @"y.txt";

            double[] array_y = Read_File(path_y);

            Console.WriteLine("\nМасив y :");
            Array_print(array_y);

            Processing_x(ref array_x);
            Console.WriteLine("\nМасив x після опрацювання :");
            Array_print(array_x);

            int num_z = Math.Min(array_x.Length, array_y.Length);

            double[] array_z = new double[num_z];

            Fill_array_z(array_x, array_y, ref array_z);

            Console.WriteLine("Масив z :");
            Array_print(array_z);
        }

        public static double[] Read_File(string path)
        {
            string[] file_text = File.ReadAllText(path).Split("\r\n");
            double[] array = new double[file_text.Length];
            for (int i = 0; i < file_text.Length; i++)
            {
                if (!double.TryParse(file_text[i], out array[i]))
                {
                    Console.WriteLine("\nУ файлі вказані некоректні значення. Перевірте файл та спробуйте знову.");
                    Environment.Exit(1);
                }
            }
            return array;
        }

        public static void Array_print(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void Processing_x(ref double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    array[i] -= 8;
                }
            }

        }

        public static void Fill_array_z(double[] x, double[] y, ref double[] z)
        {
            for (int i = 0; i < z.Length; i++)
            {
                z[i] = Math.Pow(y[i], 2) - Math.Pow(x[i], 2);
            }
        }
    }
}
