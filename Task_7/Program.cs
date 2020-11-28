using System;
using System.Text;
using System.IO;
using System.Linq;

namespace Task_7
{
    enum TypeOfWeather
    {
        не_визначено = 0,
        дощ = 1,
        короткочасний_дощ = 2,
        гроза = 3,
        сніг = 4,
        туман = 5,
        похмуро = 6,
        сонячно = 7
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            const int days_in_month = 5;

            WeatherDays weather_days = new WeatherDays();
            weather_days.GetData(days_in_month);

            Console.WriteLine("\nВиводимо інформацію за місяць:");
            weather_days.Print();

            Console.WriteLine($"\nКількість туманних днів: {weather_days.Count_Days_Fog()}");
            Console.WriteLine($"\nКількість днів коли не було опадів: {weather_days.Count_Days_Without_Precipitation()}");
            Console.WriteLine($"\nМаксимальний тиск за місяць: {weather_days.Max_atmospheric_pressure()}");
            Console.WriteLine($"\nМінімальний тиск за місяць: {weather_days.Min_atmospheric_pressure()}");

        }
    }

    class WeatherParametersDay
    {
        private double average_temperature_day;
        private double average_temperature_night;
        private double average_atmospheric_pressure;
        private double precipitation;
        private TypeOfWeather type_of_weather;

        public double Average_temperature_day
        {
            get
            {
                return average_temperature_day;
            }

            set
            {
                average_temperature_day = value;
            }
        }

        public double Average_temperature_night
        {
            get
            {
                return average_temperature_night;
            }

            set
            {
                average_temperature_night = value;
            }
        }

        public double Average_atmospheric_pressure
        {
            get
            {
                return average_atmospheric_pressure;
            }

            set
            {
                average_atmospheric_pressure = value;
            }
        }

        public double Precipitation
        {
            get
            {
                return precipitation;
            }

            set
            {
                precipitation = value;
            }
        }

        public TypeOfWeather Type_of_weather
        {
            get
            {
                return type_of_weather;
            }

            set
            {
                type_of_weather = value;
            }
        }

        public WeatherParametersDay(double average_temperature_day, double average_temperature_night, 
            double average_atmospheric_pressure, double precipitation, TypeOfWeather type_of_weather)
        {
            if (precipitation >= 0 && average_atmospheric_pressure >= 0 && Enum.IsDefined(typeof(TypeOfWeather), type_of_weather))
            {
                Average_temperature_day = average_temperature_day;
                Average_temperature_night = average_temperature_night;
                Average_atmospheric_pressure = average_atmospheric_pressure;
                Precipitation = precipitation;
                Type_of_weather = type_of_weather;
            }

            else
            {
                Console.WriteLine("Некоректні дані. Екзмепляр не ініціалізувався");
            }
        }

        public string GetString()
        {
            return ($"\t {average_temperature_day} \t {average_temperature_night} \t {average_atmospheric_pressure} \t {precipitation} \t {type_of_weather}");
        }
    
    }

    class WeatherDays
    {
        private WeatherParametersDay[] days_array;

        public WeatherParametersDay[] Days_array
        {
            get
            {
                return days_array;
            }

            set
            {
                days_array = value;
            }
        }

        public void Print()
        {
            Console.WriteLine("Число \t Вдень \t Вночі \t Тиск \t Опади \t Тип погоди");
            for (int i = 0; i < days_array.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {days_array[i].GetString()}");
            }
        }

        public int Count_Days(params TypeOfWeather[] typeOfWeathers)
        {
            int count = 0;
            for (int i = 0; i < days_array.Length; i++)
            {
                if (typeOfWeathers.Contains(days_array[i].Type_of_weather))
                {
                    count++;
                }
            }
            return count;
        }

        public int Count_Days_Without_Precipitation()
        {
            return days_array.Length - Count_Days(TypeOfWeather.дощ, TypeOfWeather.короткочасний_дощ, TypeOfWeather.сніг);
        }

        public int Count_Days_Fog()
        {
            return Count_Days(TypeOfWeather.туман);
        }

        public double Min_atmospheric_pressure()
        {
            double min = days_array[0].Average_atmospheric_pressure;
            for (int i = 1; i < days_array.Length; i++)
            {
                if (days_array[i].Average_atmospheric_pressure < min)
                {
                    min = days_array[i].Average_atmospheric_pressure;
                }
            }
            return min;
        }

        public double Max_atmospheric_pressure()
        {
            double max = days_array[0].Average_atmospheric_pressure;
            for (int i = 1; i < days_array.Length; i++)
            {
                if (days_array[i].Average_atmospheric_pressure > max)
                {
                max = days_array[i].Average_atmospheric_pressure;
            }
        }
            return max;
        }
        
        public void GetData(int days_in_month)
        {
            bool flag = true;
            Console.Write("Оберіть тип введення даних - з файлу (натисніть F) або з клавіатури (натисність K): ");
            while (flag)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.F:
                        string[] array = MyProgram.ReadFile(@"..\..\..\src\data.txt");
                        days_array = MyProgram.StringToArray(array);

                        flag = false;
                        break;

                    case ConsoleKey.K:
                        days_array = MyProgram.ReadConsole(days_in_month);

                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Натисніть F або K.");
                        break;
                }
            }
        }
    }

    class MyProgram
    {
        public static string[] ReadFile(string path)
        {
            string[] file_text_array = File.ReadAllLines(path);
            return file_text_array;
        }
         
        public static WeatherParametersDay[] StringToArray(string[] text_array)
        {
            WeatherParametersDay[] array = new WeatherParametersDay[text_array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                string[] line_split = text_array[i].Split();

                double[] result = new double[line_split.Length];
                for (int j = 0; j < line_split.Length; j++)
                {
                    if (!double.TryParse(line_split[j], out result[j]))
                    {
                        Console.WriteLine("\nУ файлі вказані некоректні значення. Перевірте файл та спробуйте знову.");
                        Environment.Exit(1);
                    }
                }
                array[i] = new WeatherParametersDay(result[0], result[1], result[2], result[3], (TypeOfWeather)result[4]);
            }
            return array;
        }


        public static WeatherParametersDay[] ReadConsole(int days_in_month)
        {
            WeatherParametersDay[] array = new WeatherParametersDay[days_in_month];

            Console.WriteLine($"\nВведіть 5 значень для погоди через пробіл для кожного дня у порядку: середня температура вдень, " +
                "середня температура вночі, середній атмосферний тиск, кількість опадів(мм / день), тип погоди за день.");

            for (int i = 0; i < days_in_month; i++)
            {
                bool Flag = true;
                while (Flag)
                {
                    Console.Write($"{i + 1}. ");
                    string[] line_split = Console.ReadLine().Split();
                    if (line_split.Length == 5)
                    {
                        double[] result = new double[line_split.Length];
                        for (int j = 0; j < line_split.Length; j++)
                        {
                            while (!double.TryParse(line_split[j], out result[j]))
                            {
                                Console.WriteLine($"\nВи вказали некоректне значення {j + 1}. Спрбуйте ще раз");
                            }
                            
                        }
                        array[i] = new WeatherParametersDay(result[0], result[1], result[2], result[3], (TypeOfWeather)result[4]);
                        Flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Введіть 5 значень, розділяючи їх пробілом.");
                    }   
                }
            }
            return array;   
        }
    }
}
