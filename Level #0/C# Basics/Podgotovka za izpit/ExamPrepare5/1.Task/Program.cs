using System;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a positive integer: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Enter the values of the array:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            bool symmetric = true;
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[n - i - 1])
                {
                    symmetric = false;
                }
            }
            Console.WriteLine("Is symmetric? {0}", symmetric);
        }
    }

