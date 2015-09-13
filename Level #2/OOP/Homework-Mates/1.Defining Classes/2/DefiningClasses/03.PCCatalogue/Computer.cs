using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PCCatalogue
{
    class Computer : IComparable
    {
        private string name;
        private List<Component> components;
        private decimal price;

        public Computer(string name, List<Component> components)
        {
            this.Name = name;
            this.Components = components;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid computer name!");
                }
                this.name = value;
            }
        }
        
        public List<Component> Components
        {
            get { return this.components; }
            private set
            {
                if (value == null)
                {
                    this.components = new List<Component>();
                }
                else
                {
                    this.components = value;
                }
            }
        }

        public decimal Price
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return 0M;
                }
                return this.Components.Sum(c => c.Price);
            }
        }

        public string Display()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Computer name: " + this.Name);
            result.AppendLine("-------------------------------");
            foreach (Component component in this.Components)
            {
                result.AppendLine(string.Format("{0,20}: {1,-25} - Price: {2} BGN", component.Name, component.Details, component.Price));
            }
            result.AppendLine("--------------------------------------------------------------------");
            result.AppendLine("\t\t\t\t\t    Total Price: " + this.Price + " BGN");

            return result.ToString();
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Computer otherComputer = obj as Computer;

            if (otherComputer != null)
            {
                return this.Price.CompareTo(otherComputer.Price);
            }

            throw new ArgumentException("Object is not a Computer!");
        }
    }
}
