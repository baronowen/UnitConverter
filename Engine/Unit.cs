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

        public string From { get; set; }

        public string To { get; set; }

        public double Value { get; set; }

        public abstract string UnitInfo();

        public abstract double Convert();

    }
}
