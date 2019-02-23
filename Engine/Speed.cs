using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class Speed : Unit
    {
        private Dictionary<string, double> sDict;

        public Speed()
        {
            sDict = new Dictionary<string, double>
            {
                { "mph", 0.44704 },
                { "fps", 0.3048 },
                { "kph", 0.27778 },
                { "mps", 1 }
            };
        }

        public override string UnitInfo()
        {
            return " - Mile/hour (mph)\n" +
                " - Feet/second (fps)\n" +
                " - Kilometer/hour (kph)\n" +
                " - Meter/second (mps)\n";
        }

        public override double Convert()
        {
            string from = From;
            string to = To;
            double value = Value;

            value = value * sDict[from] / sDict[to];

            return value;
        }
    }
}
