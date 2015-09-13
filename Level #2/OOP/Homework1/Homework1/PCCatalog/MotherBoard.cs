using System;

    class MotherBoard : Components
    {
        public MotherBoard(string name, decimal price, string details)
            :base(name, price, details)
        {
        }

        public MotherBoard(string name, decimal price)
            :base(name, price)
        {
        }
    }

