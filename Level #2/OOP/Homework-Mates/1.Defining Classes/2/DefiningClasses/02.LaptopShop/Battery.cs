using System;
using System.Text;

namespace Laptop
{
    class Battery
    {
        private string batteryType;
        private double batteryLife;

        public Battery(string type, double life)
        {
            this.BatteryType = type;
            this.BatteryLife = life;
        }

        public string BatteryType
        {
            get { return this.batteryType; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid battery type value!");
                }
                this.batteryType = value;
            }
        }

        public double BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid battery life value!");
                }
                this.batteryLife = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Battery: " + this.BatteryType);
            result.AppendLine("Battery life: " + this.BatteryLife + " hours");

            return result.ToString();
        }
    }
}
