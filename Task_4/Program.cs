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

            GetData(out double x1, out double y1, out double x2, out double y2);

            Point p_first = new Point();
            p_first.X = x1;
            p_first.Y = y1;

            Point p_last = new Point();
            p_last.X = x2;
            p_last.Y = y2;

            Segment segment_1 = new Segment();
            segment_1.First_point = p_first;
            segment_1.Last_point = p_last;

            Console.WriteLine($"\nКоординати відрізка - {segment_1.GetInfo()}");

            Console.WriteLine($"\nДовжина відрізка = {segment_1.SegmentLength()}");
            Console.WriteLine($"\nКоординати середини відрізка = {segment_1.SegmentMiddle().GetString()}");

            GetData_Zoom(out double n_zoom);

            Console.WriteLine($"\nКоординати відрізка після масштабування {segment_1.ZoomSegment(n_zoom).GetInfo()}");

        }

        static void GetData(out double x1, out double y1, out double x2, out double y2)
        {
            Console.Write("Оберіть тип введення даних - з файлу (натисніть f) або з клавіатури (натисність k): ");

            while (true)
            {
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.K)
                {
                    Console.Write("\nВведіть координату x першої точки: ");
                    string str_x1 = Console.ReadLine();
                    while (!double.TryParse(str_x1, out x1))
                    {
                        Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                        str_x1 = Console.ReadLine();
                    }

                    Console.Write("Введіть координату y першої точки: ");
                    string str_y1 = Console.ReadLine();
                    while (!double.TryParse(str_y1, out y1))
                    {
                        Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                        str_y1 = Console.ReadLine();
                    }

                    Console.Write("Введіть координату x другої точки: ");
                    string str_x2 = Console.ReadLine();
                    while (!double.TryParse(str_x2, out x2))
                    {
                        Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                        str_x2 = Console.ReadLine();
                    }

                    Console.Write("Введіть координату y другої точки: ");
                    string str_y2 = Console.ReadLine();
                    while (!double.TryParse(str_y2, out y2))
                    {
                        Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                        str_y2 = Console.ReadLine();
                    }

                    break;

                }

                else if (key == ConsoleKey.F)
                {
                    string path = @"1.txt";
                    using StreamReader sr = new StreamReader(path, Encoding.Default);

                    string val_1 = sr.ReadLine();
                    while (!double.TryParse(val_1, out x1))
                    {
                        Console.WriteLine("\nУ файлі вказані некоректні значення. Перевірте файл та спробуйте знову.");
                        Environment.Exit(1);
                    }

                    string val_2 = sr.ReadLine();
                    while (!double.TryParse(val_2, out y1))
                    {
                        Console.WriteLine("\nУ файлі вказані некоректні значення. Перевірте файл та спробуйте знову.");
                        Environment.Exit(1);
                    }

                    string val_3 = sr.ReadLine();
                    while (!double.TryParse(val_3, out x2))
                    {
                        Console.WriteLine("\nУ файлі вказані некоректні значення. Перевірте файл та спробуйте знову.");
                        Environment.Exit(1);
                    }

                    string val_4 = sr.ReadLine();
                    while (!double.TryParse(val_4, out y2))
                    {
                        Console.WriteLine("\nУ файлі вказані некоректні значення. Перевірте файл та спробуйте знову.");
                        Environment.Exit(1);
                    }

                    break;
                }

                else
                {
                    Console.WriteLine("\nНатисніть клавішу f або k");
                }
            }

        }

        static void GetData_Zoom(out double n_zoom)
        {
            Console.Write("\nВведіть коефіцієнт для масштабування відрізка: ");
            string str_n = Console.ReadLine();
            while (!double.TryParse(str_n, out n_zoom) || n_zoom <= 0)
            {
                Console.WriteLine("\nНекоректне значення, спробуйте ще раз...");
                str_n = Console.ReadLine();
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

        //public Point(double x, double y)
        //{
        //    X = x;
        //    Y = y;
        //}

        public string GetString()
        {
            return ($"({x};{y})");
        }
    }

    class Segment
    {
        private Point first_point;
        private Point last_point;

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

        //public Segment(Point first, Point last)
        //{
        //    First_point = first;
        //    Last_point = last;
        //}

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

        public Segment ZoomSegment(double n)
        {
            Segment SgmZoom = new Segment();
            SgmZoom.First_point = first_point;
            SgmZoom.Last_point = last_point;

            SgmZoom.last_point.X = first_point.X * (1 - n) + last_point.X * n;
            SgmZoom.last_point.Y = first_point.Y * (1 - n) + last_point.Y * n;

            return (SgmZoom);
        }


    }
}
