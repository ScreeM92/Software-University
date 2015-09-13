using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input < 0)
                {
                    throw new IndexOutOfRangeException("The number cannot be negative");
                }
                Console.WriteLine(Math.Sqrt(input));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
