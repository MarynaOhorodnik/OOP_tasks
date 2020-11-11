using System;
using System.IO;
using System.Text;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;           

            Segment segment_1 = new Segment();
            segment_1.Getdata();

            Console.WriteLine($"\nКоординати відрізка - {segment_1.GetInfo()}");

            Console.WriteLine($"\nДовжина відрізка = {segment_1.SegmentLength()}");
            Console.WriteLine($"\nКоординати середини відрізка = {segment_1.SegmentMiddle().GetString()}");

            Console.WriteLine($"\nКоординати відрізка після масштабування {segment_1.ZoomSegment().GetInfo()}");

        }

    }

    
    class Segment
    {
        private Point first_point = new Point();
        private Point last_point = new Point();

        public Point First_point
        {
            get
            {
                return first_point;
            }

            set
            {
                first_point = value;
            }
        }

        public Point Last_point
        {
            get
            {
                return last_point;
            }

            set
            {
                last_point = value;
            }
        }



        public string GetInfo()
        {
            return ($"{first_point.GetString()} та {last_point.GetString()}");
        }

        public double SegmentLength()
        {
            double length = Math.Sqrt(Math.Pow(last_point.X - first_point.X, 2) + Math.Pow(last_point.Y - first_point.Y, 2));
            return length;
        }

        public Point SegmentMiddle()
        {
            Point SgmMiddle = new Point();
            SgmMiddle.X = (last_point.X + first_point.X) / 2;
            SgmMiddle.Y = (last_point.Y + first_point.Y) / 2;
            return (SgmMiddle);
        }

        public Segment ZoomSegment()
        {
            double n;

            Console.Write("\nВведіть коефіцієнт для масштабування відрізка: ");
            string str_n = Console.ReadLine();

            while (!double.TryParse(str_n, out n) || n <= 0)
            {
                Console.WriteLine("\nНекоректне значення, спробуйте ще раз...");
                str_n = Console.ReadLine();
            }
            Segment SgmZoom = new Segment();
            SgmZoom.First_point = first_point;
            SgmZoom.Last_point = last_point;

            SgmZoom.last_point.X = first_point.X * (1 - n) + last_point.X * n;
            SgmZoom.last_point.Y = first_point.Y * (1 - n) + last_point.Y * n;

            return (SgmZoom);
        }

        public void Getdata()
        {
            Console.Write("Оберіть тип введення даних - з файлу (натисніть f) або з клавіатури (натисність k): ");
            while (true)
            {
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.K)
                {

                    first_point.GetData_k("першої");
                    last_point.GetData_k("другої");
                    break;

                }

                else if (key == ConsoleKey.F)
                {
                    string path = @"1.txt";
                    using StreamReader sr = new StreamReader(path, Encoding.Default);

                    first_point.GetData_f(sr);
                    last_point.GetData_f(sr);

                    break;
                }

                else
                {
                    Console.WriteLine("\nНатисніть клавішу f або k");
                }

            }
        }
    }


    class Point
    {
        private double x;
        private double y;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public string GetString()
        {
            return ($"({x};{y})");
        }

        public double coordinate_keyb(string name)
        {
            double xy = 0;
            Console.Write($"\nВведіть координату {name} точки: ");
            string str_1 = Console.ReadLine();
            while (!double.TryParse(str_1, out xy))
            {
                Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                str_1 = Console.ReadLine();
            }

            return xy;
        }

        public double coordinate_file(StreamReader sr)
        {
            double xy = 0;
            string val_1 = sr.ReadLine();
            while (!double.TryParse(val_1, out xy))
            {
                Console.WriteLine("\nУ файлі вказані некоректні значення. Перевірте файл та спробуйте знову.");
                Environment.Exit(1);
            }

            return xy;
        }

        public void GetData_k(string name)
        {
            x = coordinate_keyb($"x {name}");
            y = coordinate_keyb($"y {name}");

        }

        public void GetData_f(StreamReader sr)
        {
            x = coordinate_file(sr);
            y = coordinate_file(sr);

        }
    }

}
