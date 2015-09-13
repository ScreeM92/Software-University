using System;
using System.Linq;
    class TEST_Student
    {
        static void Main(string[] args)
        {
            //Student misho = new Student(22, "Misho", "0888 444 333");
            //Console.WriteLine(misho.myFunc(5));

            Random rnd = new Random();
            int[] nums = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                nums[i] = rnd.Next(-5000, 5001);
            }
            var sum = nums.Where(num => num > 0 && num % 10 == 7).Sum();

        }
        
    }

