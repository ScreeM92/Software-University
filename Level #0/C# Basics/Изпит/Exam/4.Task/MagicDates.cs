using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task
{
    class Program
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            DateTime startD = new DateTime(first, 1, 1);
            DateTime endD = new DateTime(second, 12, 31);

            bool found = false;

            for (DateTime currentD = startD; currentD <= endD; startD.AddDays(1))
            {
                string data = string.Format("{0}{1}{2}", currentD.Day, currentD.Month, currentD.Year);
                int currentMnum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    for (int j = 0; j < data.Length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        currentMnum += (data[i] - '0') * (data[j] - '0');
                    }
                }
                if (currentMnum / 2 == magicNum)
                {
                    found = true;
                    Console.WriteLine("{0}-{1}-{2}", currentD.Day, currentD.Month, currentD.Year);
                }
            }
            if (found == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
        