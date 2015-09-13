using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

    class Computer
    {
        private string name;
        private IList<Components> components;

        public Computer(string name)
        {
            this.Name = name;
            this.Components = new List<Components>();
        }

        public Computer(string name, IList<Components> components)
            :this(name)
        {
            this.Components = components;
        }

        public decimal TotalPrice
        {
            get
            {
                return this.Components.Sum(a => a.Price);
            }
            private set
            {
                this.TotalPrice = TotalPrice;
            }
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

        public IList<Components> Components
        {
            get
            {
                return this.components;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("The components cannot be null");
                }
                this.components = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Computer name: {0}\nPrice: {1:C}\nComponents:\n", this.Name, this.TotalPrice);
            foreach (var item in this.Components)
            {
                str.Append(item);
            }
            return str.ToString();
        }
    }

