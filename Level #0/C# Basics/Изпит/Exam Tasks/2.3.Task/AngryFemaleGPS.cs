using System;

class AngryFemalesGPS
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        if (N < 0)
        {
            N = -N;
        }
        string input = N.ToString();
        int oddSum = 0;
        int evenSum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] % 2 == 0)
            {
                evenSum += int.Parse(input[i].ToString());
            }
            else
            {
                oddSum += int.Parse(input[i].ToString());
            }
        }
        if (evenSum > oddSum)
        {
            Console.WriteLine("right {0}", evenSum);
        }
        else if (evenSum < oddSum)
        {
            Console.WriteLine("left {0}", oddSum);
        }
        else
        {
            Console.WriteLine("straight {0}", oddSum);
        }
        Console.WriteLine();
    }
}
	
    // 2-ro reshenie

    //using System;
     
    //class AngryGps
    //{
    //    static void Main()
    //    {
    //        string input = Console.ReadLine();
    //        int evenSum = 0;
    //        int oddSum = 0;
    //        for (int i = 0; i < input.Length; i++)
    //        {
    //            switch (input[i])
    //            {
    //                case '1': oddSum += 1;
    //                    break;
    //                case '2': evenSum += 2;
    //                    break;
    //                case '3': oddSum += 3;
    //                    break;
    //                case '4': evenSum += 4;
    //                    break;
    //                case '5': oddSum += 5;
    //                    break;
    //                case '6': evenSum += 6;
    //                    break;
    //                case '7': oddSum += 7;
    //                    break;
    //                case '8': evenSum += 8;
    //                    break;
    //                case '9': oddSum += 9;
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
     
    //        if (oddSum > evenSum)
    //        {
    //            Console.WriteLine("left {0}", oddSum);
    //        }
    //        else if (evenSum > oddSum)
    //        {
    //            Console.WriteLine("right {0}", evenSum);
     
    //        }
    //        else
    //        {
    //            Console.WriteLine("straight {0}", evenSum);
    //        }
     
     
    //    }
    //}




