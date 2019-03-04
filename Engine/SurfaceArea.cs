using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class SurfaceArea : Unit
    {
        private Dictionary<string, double> sAreaDict;

        public SurfaceArea()
        {
            sAreaDict = new Dictionary<string, double>
            {
                { "km^2", 1000000 },
                { "hm^2", 10000 },
                { "dam^2",100 },
                { "m^2",  1 },
                { "dm^2", 0.01 },
                { "cm^2", 0.0001 },
                { "mm^2", 0.000001 }
            };
        }

        public override string UnitInfo()
        {
            return " - Square Kilometre (km^2)\n" +
                " - Square Hectometre (hm^2)\n" +
                " - Square Decametre (dam^2)\n" +
                " - Square Metre (m^2)\n" +
                " - Square Decimetre (dm^2)\n" +
                " - Square Centimetre ( cm^2)\n" +
                " - Square Milimetre (mm^2)\n";
        }

        public override double Convert()
        {
            string from = From;
            string to = To;
            double value = Value;

            value = value * sAreaDict[from] / sAreaDict[to];

            return value;
        }
    }
}
