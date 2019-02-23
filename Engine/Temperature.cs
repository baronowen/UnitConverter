using System;

namespace Engine
{
    public class Temperature : Unit
    {
        public override string UnitInfo()
        {
            return " - Celsius(c)\n - Fahrenheit(f)\n - Kelvin(k)\n";
        }

        public override double Convert()
        {
            string from = From;
            string to = To;
            double value = Value;

            if (from == "c")
            {
                value += 273.15;
            } else if (from == "f")
            {
                value = (value - 32) * 5 / 9 + 273.15;
            }

            if (to == "c")
            {
                value -= 273.15;
            } else if (to == "f")
            {
                value = (value - 273.15) * 9 / 5 + 32;
            }

            return value;
        }
    }
}
