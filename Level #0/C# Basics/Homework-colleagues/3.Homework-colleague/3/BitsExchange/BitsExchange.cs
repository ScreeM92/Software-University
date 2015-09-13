using System;

    class BitsExchange
    {
        static void Main()
        {
            Console.Write("Your Number: ");
            uint theNumber = Convert.ToUInt32(Console.ReadLine());

            long number = Convert.ToUInt32(theNumber);
            long changed = number >> 3;

            long bit3 = changed & 1;
            Console.WriteLine("bit3= " + bit3);

            changed = changed >> 1;
            long bit4 = changed & 1;
            Console.WriteLine("bit4= " + bit4);

            changed = changed >> 1;
            long bit5 = changed & 1;
            Console.WriteLine("bit5= " + bit5);

            changed = changed >> 19;
            long bit24 = changed & 1;
            Console.WriteLine("bit24= "+bit24);

            changed = changed >> 1;
            long bit25 = changed & 1;
            Console.WriteLine("bit25= " + bit25);

            changed = changed >> 1;
            long bit26 = changed & 1;
            Console.WriteLine("bit26= " + bit26);

            //--------------------------------------------

            if (bit24 == 1 && bit3 == 0)
            {
                long mask = 1 << 24;
                number = number & ~mask;
          

            }
            if (bit24 == 0 && bit3 == 1)
            {
                long mask = 1 << 24;
                number = number | mask;
                
            }
            //-------

            if (bit25 == 1 && bit4 == 0)
            {
                long mask = 1 << 25;
                number = number & ~mask;
               

            }
            if (bit25 == 0 && bit4 == 1)
            {
                long mask = 1 << 25;
                number = number | mask;
               
            }
            //----------

                if (bit26 == 1 && bit5 == 0)
            {
                long mask = 1 << 26;
                number = number & ~mask;
                

            }
            if (bit24 == 0 && bit5 == 1)
            {
                long mask = 1 << 26;
                number = number | mask;
                
            }
            Console.WriteLine(number);
            Console.ReadLine();

        }
    }