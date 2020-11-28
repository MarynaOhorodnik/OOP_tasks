using System;
using System.Text;


namespace Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            MyComplex A = new MyComplex(1, 1);
            MyComplex B = new MyComplex();
            MyComplex C = new MyComplex(1);
            MyComplex D = new MyComplex();

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");

            C = A + B;
            Console.WriteLine($"\nC = A + B => \t\t C = {C}");

            C = A + 10.5;
            Console.WriteLine($"C = A + 10.5 => \t C = {C}");

            C = 10.5 + A;
            Console.WriteLine($"C = 10.5 + A => \t C = {C}");

            D = -C;
            Console.WriteLine($"D = -C => \t\t D = {D}");

            C = A + B + C + D;
            Console.WriteLine($"C = A + B + C + D => \t C = {C}");

            C = A = B = C;

            Console.WriteLine($"C = A = B = C => \t A = {A}, B = {B}, C = {C}");

            D.InputFromTerminal();

            Console.WriteLine($"\nA = {A}, B = {B}, C = {C}, D = {D}");

            Console.WriteLine();
            Console.WriteLine($"Re(A) = {A["realValue"]}, Im(A) = {A["imageValue"]}");
            Console.WriteLine($"Re(B) = {B["realValue"]}, Im(B) = {B["imageValue"]}");
            Console.WriteLine($"Re(C) = {C["realValue"]}, Im(C) = {C["imageValue"]}");
            Console.WriteLine($"Re(D) = {D["realValue"]}, Im(D) = {D["imageValue"]}");

        }
    }

    class MyComplex
    {
        private double Re, Im;

        public MyComplex(double re = 0, double im = 0)
        {
            Re = re;
            Im = im;
        }

        public double this[string key]
        {
            get
            {
                switch (key)
                {
                    case "realValue":
                        return Re;
                    case "imageValue":
                        return Im;
                    default:
                        return 0;
                }
            }
        }

        public static MyComplex operator +(MyComplex A, MyComplex B)
        {
            return new MyComplex(A.Re + B.Re, A.Im + B.Im);
        }

        public static MyComplex operator +(MyComplex A, double B)
        {
            return new MyComplex(A.Re + B, A.Im);
        }

        public static MyComplex operator +(double A, MyComplex B)
        {
            return B + A;
        }

        public static MyComplex operator -(MyComplex A)
        {
            return new MyComplex(-A.Re, -A.Im);
        }

        public static MyComplex operator /(MyComplex A, MyComplex B)
        {
            return new MyComplex(A.Re * B.Re, A.Im * B.Im);
        }

        public void InputFromTerminal()
        {
            Re = ReadConsole("реальну");
            Im = ReadConsole("уявну");
        }

        public double ReadConsole(string str)
        {
            double a = 0;
            Console.Write($"\nВведіть {str} частину числа: ");
            string str_1 = Console.ReadLine();
            while (!double.TryParse(str_1, out a))
            {
                Console.WriteLine("Некоректне значення, спробуйте ще раз...");
                str_1 = Console.ReadLine();
            }

            return a;
        }

        public override string ToString()
        {
            if (Im >= 0)
            {
                return $"{Re}+{Im}*i";
            }

            return $"{Re}{Im}*i";
        }
    }
}
