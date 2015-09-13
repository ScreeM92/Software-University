using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class TelerikLogo
    {
        static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            int z = (x / 2) + 1;
            int lenght = (2 * z) + (2 * x) - 3;
            int innerDots = lenght - (2 * z);
            int outerDots = x / 2;
            int middleDots = 
            Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));

            for (int i = 0; i < z - 1; i++)
            {
                outerDots --;
                innerDots -= 2;

                Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string ('.', outerDots), new string(' .',      middleDots), new string('.', innerDots));

                middleDots += 2;
            }
            if (x != 3)
	           {
		         
	           }
        }
    }

