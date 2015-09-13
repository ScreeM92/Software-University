using System;
class FormattingNumbers
{
    static void Main()
    {
        {
            Console.WriteLine("Input an integer a:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Input a floating-point b :");
            float num2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Input a floating-point c :");
            float num3 = float.Parse(Console.ReadLine());
            string binary = Convert.ToString(num1, 2).PadLeft(10, '0');
            if (num1 <= 500 & num1 >= 0)
            {
                Console.Write("|{0,-10:X}|{1}", num1, binary);
                bool dotCheckB = Convert.ToString(num2).IndexOf(".") > 0;
                Console.Write(dotCheckB ? "|{0,10:0.00}" : "|{0,10}", num2);
                bool dotCheckC = Convert.ToString(num3).IndexOf(".") > 0;
                Console.WriteLine(dotCheckC ? "|{0,-10:0.000}|" : "|{0,-10}|", num3);
            }
            else
            {
                Console.WriteLine("Number a is not between 0 ≤ a ≤ 500.");
            }
        }
        // 2ri variant

        //Console.Write("Please enter an integer between 0 and 500: ");
        //int a = int.Parse(Console.ReadLine());
        //Console.Write("Please enter a floating-point number: ");
        //double b = double.Parse(Console.ReadLine());
        //Console.Write("Please enter another floating-point number: ");
        //double c = double.Parse(Console.ReadLine());

        //string lastColumn = string.Empty;
        //if ((int)c == c)
        //{
        //    lastColumn = string.Format("{0,-10}", c);
        //}
        //else
        //{
        //    lastColumn = string.Format("{0,-10:F3}", c);
        //}

        //Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3}|", a, Convert.ToString(a, 2).PadLeft(10, '0'), b, lastColumn);
    }
}