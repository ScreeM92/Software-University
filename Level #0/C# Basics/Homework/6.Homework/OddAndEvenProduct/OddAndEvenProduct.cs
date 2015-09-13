using System;
class OddAndEvenProduct
    {
        static void Main()
        {
            string[] numstr = Console.ReadLine().Split();
            int[] nums = new int[numstr.Length];
            for (int i = 0; i < numstr.Length; i++)
            {
                nums[i] = int.Parse(numstr[i]);
            }
            int productEven = 1;
            int productOdd = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 != 0)
                {
                    productEven *= nums[i];
                }
                else
                {
                    productOdd *= nums[i];
                }
            }
            //or
            //for (int i = 0; i < nums.Length; i += 2)
            //{
            //    productOdd *= nums[i];
            //}
            //for (int i = 1; i < nums.Length; i += 2)
            //{
            //    productEven *= nums[i];
            //}
            if (productEven == productOdd)
            {
                Console.WriteLine("yes");
                Console.WriteLine("product: {0}", productOdd);
            }
            else
            {
                Console.WriteLine("no");
                Console.WriteLine("odd_product = {0}", productOdd);
                Console.WriteLine("even_product = {0}", productEven);
            }
        }
    }

