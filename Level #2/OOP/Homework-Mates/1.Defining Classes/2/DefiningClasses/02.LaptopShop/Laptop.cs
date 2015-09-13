using System;
using System.Text;

namespace Laptop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private decimal price;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, string ram = null, string hdd = null, string graphicsCard = null, Battery battery = null, string screen = null)
            : this(model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid model value!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if(value != null && value.Length == 0)
                {
                    throw new ArgumentException("Invalid manufacturer value!");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Invalid processor value!");
                }
                this.processor = value;
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Invalid ram value!");
                }
                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Invalid graphics card value!");
                }
                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Invalid hdd value!");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Invalid screen value!");
                }
                this.screen = value;
            }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid price!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Model: " + this.Model);

            if (this.Manufacturer != null)
            {
                result.AppendLine("Manufacturer: " + this.Manufacturer);
            }

            if (this.Processor != null)
            {
                result.AppendLine("Processor: " + this.Processor);
            }

            if (this.Ram != null)
            {
                result.AppendLine("RAM: " + this.Ram);
            }

            if(this.GraphicsCard != null)
            {
                result.AppendLine("Graphics Card: " + this.GraphicsCard);
            }

            if (this.Hdd != null)
            {
                result.AppendLine("HDD: " + this.Hdd);
            }

            if (this.Screen != null)
            {
                result.AppendLine("Screen: " + this.Screen);
            }

            if(this.Battery != null)
            {
                result.AppendLine(this.Battery.ToString());
            }

            result.AppendLine("Price: " + this.Price + " lv.");
            result.AppendLine("---------------------------------------------------------------");

            return result.ToString();
        }
    }
}
