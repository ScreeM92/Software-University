using System;

    class Processor : Components
    {

        public Processor(string name, decimal price, string details)
            : base(name, price, details)
        {
        }

        public Processor(string name, decimal price)
            : base(name, price)
        {
        }      
    }

