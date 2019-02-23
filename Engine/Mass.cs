using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class Mass : Unit
    {
        private Dictionary<string, double> mDict;

        public Mass()
        {
            mDict = new Dictionary<string, double>
            {
                { "ton", 1000 },
                { "kg", 1 },
                { "g", 0.001 },
                { "mg", 0.000001 },
                { "lb", 0.45359237 },
                { "oz", 0.0283495 }
            };
        }

        public override string UnitInfo()
        {
            return " - Metric ton (ton)\n" +
                " - Kilogram (kg)\n" +
                " - Gram (g) \n" +
                " - Milligram (mg)\n" +
                " - Pound (lb)\n" +
                " - Ounce (oz)\n";
        }

        public override double Convert()
        {
            string from = From;
            string to = To;
            double value = Value;

            value = value * mDict[from] / mDict[to];

            return value;
        }
    }
}
