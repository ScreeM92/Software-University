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
            Console.WriteLine("Enter a number > 0: ");
            try
            {
                string input = Console.ReadLine();
                double parced = Double.Parse(input);

                if (parced < 0)
                {
                    throw new ApplicationException("Invalid number. The value must not be negative or zero.");
                }

                double result = Math.Sqrt(parced);
                Console.WriteLine("Square root: {0}", result);
                return;
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.Error.WriteLine("Invalid number" + aoore);
            }
            catch (FormatException fe)
            {
                Console.Error.WriteLine("Invalid input. Enter a number." + fe);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Invalid input" + ex);
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }

        }
    }
}
