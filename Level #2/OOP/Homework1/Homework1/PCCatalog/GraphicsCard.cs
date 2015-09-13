using System;

    class GraphicsCard : Components
    {
        public GraphicsCard(string name, decimal price, string details)
            :base(name, price, details)
        {
        }

        public GraphicsCard(string name, decimal price)
            :base(name, price)
        {
        }
    }

