using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class UnitFactory
    {
        public Unit GetUnit(string unitType)
        {
            if (unitType == "temperature")
            {
                return new Temperature();
            }
            else
            {
                return null;
            }
        }
    }
}
