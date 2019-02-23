using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class Length : Unit
    {
        private Dictionary<string, double> lDict;

        public Length()
        {
            lDict = new Dictionary<string, double>
            {
                { "km", 1000 },
                { "m", 1 },
                { "cm", 0.01 },
                { "mm", 0.001 },
                { "mi", 1609.344 },
                { "yd", 0.9144 },
                { "ft", 0.3048 },
                { "in", 0.0254 }
            };
        }

        public override string UnitInfo()
        {
            return " - Kilometer (km)\n" +
                " - Meter (m)\n" +
                " - Centimeter (cm)\n" +
                " - Millimeter (mm)\n" +
                " - Mile (mi)\n" +
                " - Yard (yd)\n" +
                " - Foot (ft) \n" +
                " - Inch (in) \n";
        }

        public override double Convert()
        {
            string from = From;
            string to = To;
            double value = Value;

            value = value * lDict[from] / lDict[to];

            return value;

        }
    }
}
