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
            Dictionary<string, string> measurements = new Dictionary<string, string>();
            measurements.Add("temp", "temperature");

            bool temp = true;

            Intro();
            while (temp)
            {
                string answer = "";
                ConvertProcess(measurements);

                Console.WriteLine("Do you want to convert something else? Yes(y) or No(n)?");
                answer = Console.ReadLine();

                CheckAnswer(answer);

                if (answer.ToLower().StartsWith("n"))
                {
                    temp = false;
                }
            }
        }

        public static void UserInput(Unit unit)
        {
            Console.WriteLine("Convert value: ");
            unit.Value = Double.Parse(Console.ReadLine());
            Console.WriteLine("from: ");
            unit.From = Console.ReadLine();
            Console.WriteLine("to: ");
            unit.To = Console.ReadLine();
            Console.WriteLine();
            // TODO: add error handling in this function.
        }

        public static void Intro()
        {
            Console.WriteLine("A simple converter program.");
        }

        public static Unit GetMeasurementUnit(Dictionary<string, string> measurements)
        {
            string type = "";
            UnitFactory unitFactory = new UnitFactory();
            Console.WriteLine("The measurement types that you can use:\n" +
                " - Temperature (temp)\n" +
                " - Length (len)(TO BE IMPLEMENTED)\n" +
                "\n" +
                "What measurement type do you wish to use? Type the short name.");
            type = Console.ReadLine();
            while (!measurements.ContainsKey(type))
            {
                Console.WriteLine("Wrong input! Please type your choice again.");
                type = Console.ReadLine();
            }
            //Console.WriteLine("\ntype: " + type + " value: " + measurements[type] + "\n");
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
                Console.WriteLine("Conversion resulted in: " + val + "\n");

                Console.WriteLine("Do you want to convert another one? Yes(y) or No(n)?");
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
