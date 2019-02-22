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
            UnitFactory unitFactory = new UnitFactory();
            Unit unit = unitFactory.GetUnit("temperature");

            unit.UnitInfo();

            unit.UserInput();

            double val = unit.Convert();
            Console.WriteLine(val);
        }
    }
}
