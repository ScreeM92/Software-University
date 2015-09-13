using System;
class DecimalToBinaryNumber
{
    static void Main()
    {
        //1 variant
        //int dec = int.Parse(Console.ReadLine());
        //string binary = Convert.ToString(dec, 2);
        //Console.WriteLine(binary);

        //2 variant
        long decNumber = long.Parse(Console.ReadLine());
        string binNumber = "";
        while (decNumber != 0)
        {
            int remain = (int)decNumber % 2;
            decNumber /= 2;
            binNumber = remain + binNumber;
        }
        Console.WriteLine(binNumber);

        //3 variant
        //int dec = int.Parse(Console.ReadLine());
        //char[] binary = new char[32];
        //int index = 0;
        //while (dec != 0)
        //{
        //    binary[index] = (char)('0' + (dec % 2));
        //    dec /= 2;
        //    index++;
        //}
        //Console.WriteLine(binary);

        //for (int i = 0; i <= (index -1) /2; i++)
        //{
        //    char tmp = binary[i];
        //    binary[i] = binary[index - 1 - i];
        //    binary[index - 1 - i] = tmp;
        //}
        //Console.WriteLine(binary);
    }
}

