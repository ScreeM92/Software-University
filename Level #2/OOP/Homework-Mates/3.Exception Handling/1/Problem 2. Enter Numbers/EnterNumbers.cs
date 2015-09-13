using System;

class EnterNumbers
{
    static int ReadNumber(int start, int end)
    {
        int result;
        result = int.Parse(Console.ReadLine());
        if (!((result > start) && (result < end)))
        {
            throw new OverflowException("Value is not in range [" + start + ".." + end + "].\n");
        }
        return result;
    }
            
    static void Main()
    {
        int[] arrayInt = new int[10];
         
        for (int i = 0; i < arrayInt.Length; i++)
		{
            try
            {
                Console.Write("Enter number: ");
                arrayInt[i] = ReadNumber(1, 100);
                if (i > 0)
                {
                    if (arrayInt[i] < arrayInt[i - 1])
                    {
                        Console.Error.WriteLine("\nThe Value entered is not in range {0} .. {1}. Please enter correct value", arrayInt[i - 1], 100);
                        i--;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine("Not Valid Integer value\n" + ex.Message);
                i--;
            }
            catch (OverflowException ex)
            {
                Console.Error.WriteLine(ex.Message + "Please enter valid value");
                i--;
            }
        }
    }
}
