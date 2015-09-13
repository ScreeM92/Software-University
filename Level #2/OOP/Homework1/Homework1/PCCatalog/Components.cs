using System;
using System.Text;
    public abstract class Components
    {
        private string name;
        private decimal price;
        private string details = null;

        public Components(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Components(string name, decimal price, string details)
            :this(name, price)
        {
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tha name cannot be null or whitespace");
                }
                this.name = value;
            }
        }

        public decimal Price 
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price cannot be negative");
                }
                this.price = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if(value != null && value.Length < 1)
                {
                    throw new ArgumentException("The details can be null or string");
                }
                this.details = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendFormat("Name: {0}, Price: {1:C}", this.Name, this.Price);
            if (this.Details != null)
            {
                str.AppendFormat(", Details: {0}\n", this.Details);
            }
            return str.ToString();
        }
    }

