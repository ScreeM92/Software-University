using System;

    class BitsExchange
    {
        static void Main()
        {
            Console.Write("Your Number: ");
            uint theNumber = Convert.ToUInt32(Console.ReadLine());
                    //Console.WriteLine(Convert.ToString(theNumber, 2)); just checking

            uint altered = theNumber << 4;
            altered = altered >> 7;
                    //Console.WriteLine(Convert.ToString(altered, 2)); just checking
            int number = (int)altered;
                    //Console.WriteLine(Convert.ToString(number, 2)); just checking

            int bit3 = number & 1;
            Console.WriteLine("bit3= "+bit3);
            int changed = number >> 1;
            int bit4 = changed & 1;
            Console.WriteLine("bit4= " + bit4);
            changed = changed >> 1;
            int bit5 = changed & 1;
            Console.WriteLine("bit5= " + bit5);
            //-------------------------------------------------------------
            //changing 3rd and 24th
            Console.WriteLine(Convert.ToString(changed, 2));
            changed = changed >> 19;
            int bit24 = changed & 1;
            Console.WriteLine("bit24= " + bit24);

            if (bit24 == 1 && bit3 == 0)
            {
                int mask = 1 << 20;
                number = number & ~mask;
                Console.WriteLine(number);

            }
            if (bit24 == 0 && bit3 == 1)
            {
                int mask = 1 << 20;
                number = number | mask;
                Console.WriteLine(number);
            }
            //changing 4th and 25th
            changed = changed >> 1;
            int bit25 = changed & 1;
            Console.WriteLine("bit25= " + bit25);

            if (bit25 == 1 && bit4 == 0)
            {
                int mask = 1 << 21;
                number = number & ~mask;
                Console.WriteLine(number);

            }
            if (bit25 == 0 && bit4 == 1)
            {
                int mask = 1 << 21;
                number = number | mask;
                Console.WriteLine(number);
            }
           
            //changing 5th and 26th
            changed = changed >> 1;
            int bit26 = changed & 1;
            Console.WriteLine("bit26= " + bit26);

            if (bit26 == 1 && bit5 == 0)
            {
                int mask = 1 << 22;
                number = number & ~mask;
                Console.WriteLine(number);

            }
            if (bit24 == 0 && bit5 == 1)
            {
                int mask = 1 << 22;
                number = number | mask;
                Console.WriteLine(number);
            }

            Console.WriteLine(Convert.ToString(number, 2));


        }
    }
