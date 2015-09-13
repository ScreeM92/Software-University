using System;
    class Test
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(SquareRoot.CalculateSqr(4));
                //Console.WriteLine(SquareRoot.CalculateSqr(-1));
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid number");
            }
            catch(ArgumentNullException)
            {
                throw new ArgumentException("Invalid number");
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }

    class SquareRoot
    {

        public static double CalculateSqr(int num)
    {
        if (num < 0)
        {
            throw new ArgumentOutOfRangeException("Number can not be negative");
        }
        double result = Math.Sqrt(num);
        return result;
    }
}

