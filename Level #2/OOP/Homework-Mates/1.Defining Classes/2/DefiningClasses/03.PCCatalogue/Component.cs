using System;
using System.Collections.Generic;

namespace PCCatalogue
{
    class Component
    {
        private string name;
        private string details;
        private decimal price;

        public Component(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid component name!");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid component price!");
                }
                this.price = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (value != null && value.Length == 0)
                {
                    throw new ArgumentException("Invalid component details!");
                }
                this.details = value;
            }
        }
    }
}
