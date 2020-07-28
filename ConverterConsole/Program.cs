using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace ConverterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> measurements = new Dictionary<string, string>
            {
                { "temp", "temperature" },
                { "len", "length" },
                { "m", "mass" },
                { "spd", "speed" },
                { "srfa", "surface area" }
            };

            bool running = true;

            Intro();
            while (running)
            {
                string answer = "";
                ConvertProcess(measurements);

                Console.WriteLine("Do you want to convert another unit type? Yes(y) or No(n)?");
                answer = Console.ReadLine();

                CheckAnswer(answer);

                if (answer.ToLower().StartsWith("n"))
                {
                    running = false;
                }
            }
        }

        public static void UserInput(Unit unit)
        {
            Console.WriteLine("Convert from: ");
            unit.From = Console.ReadLine();
            Console.WriteLine("to: ");
            unit.To = Console.ReadLine();
            Console.WriteLine("with value of: ");
            unit.Value = double.Parse(Console.ReadLine());
            Console.WriteLine();
            
        }

        public static void Intro()
        {
            Console.WriteLine("A simple converter program.\n");
        }

        public static Unit GetMeasurementUnit(Dictionary<string, string> measurements)
        {
            string type = "";
            UnitFactory unitFactory = new UnitFactory();
            Console.WriteLine("The measurement types that you can use:\n" +
                " - Temperature (temp)\n" +
                " - Length (len)\n" +
                " - Mass (m)\n" +
                " - Speed (spd)\n" +
                " - Surface Area (srfa)\n" +
                "\n" +
                "What measurement type do you wish to use? Type the short name.");
            type = Console.ReadLine();
            while (!measurements.ContainsKey(type))
            {
                Console.WriteLine("Wrong input! Please type your choice again.");
                type = Console.ReadLine();
            }
            return unitFactory.GetUnit(measurements[type]);
        }

        public static void ConvertProcess(Dictionary<string, string> measurements)
        {
            Unit unit = GetMeasurementUnit(measurements);

            bool temp = true;

            while (temp)
            {
                string reply = "";
                Console.WriteLine("Your choices: ");

                string choices = unit.UnitInfo();
                Console.WriteLine(choices);
                UserInput(unit);

                double val = unit.Convert();
                string s = String.Format("Conversion result: {0}{1} is {2}{3}\n", unit.Value, unit.From, val, unit.To);
                Console.WriteLine(s);

                Console.WriteLine("Do you want to convert another number? Yes(y) or No(n)?");
                reply = Console.ReadLine();

                CheckAnswer(reply);

                if (reply.ToLower().StartsWith("n"))
                {
                    temp = false;
                }
            }
        }

        public static void CheckAnswer(string answer)
        {
            while (!answer.ToLower().StartsWith("n") && !answer.ToLower().StartsWith("y"))
            {
                Console.WriteLine("Please enter Yes(y) or No(n)!");
                answer = Console.ReadLine();
            }
        }
    }
}
