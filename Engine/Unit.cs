using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public abstract class Unit
    {
        private string from;
        private string to;
        private double value;

        public Unit()
        {
            this.from = "";
            this.to = "";
            this.value = 0;
        }

        public string From { get; private set; }

        public string To { get; private set; }

        public double Value { get; private set; }

        public void UserInput()
        {
            Console.WriteLine("Convert value: ");
            Value = Double.Parse(Console.ReadLine());
            Console.WriteLine("from: ");
            From = Console.ReadLine();
            Console.WriteLine("to: ");
            To = Console.ReadLine();
            Console.WriteLine();
        }

        public abstract void UnitInfo();

        public abstract double Convert();

    }
}
