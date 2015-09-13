using System;
    class GenericListTest
    {
        static void Main()
        {
            GenericList<int> test = new GenericList<int>(2);
            test.Add(1);
            test.Add(2);
            test.Add(10);
            test.Add(99);
            test.Add(22);
            test.Add(40);
            test.Add(121);
            test.Add(23);
            Console.WriteLine(test);
            Console.WriteLine(test[3]);
            Console.WriteLine(test.IndexOf(121));
            test.Remove(3);
            Console.WriteLine(test);
            Console.WriteLine(test[3]);
            Console.WriteLine(test.IndexOf(121));
            test.Insert(66, 4);
            Console.WriteLine(test);
            test.Insert(66, 4);
            Console.WriteLine(test);
            Console.WriteLine(test.Count);
            Console.WriteLine("Max: " + test.Max());
            Console.WriteLine("Min: " + test.Min());

            Console.WriteLine(test.Contains(121));

            Console.WriteLine();
            var allAttributes = typeof(GenericList<>).GetCustomAttributes(typeof(VersionAttribute), false);
            Console.WriteLine("Version: " + allAttributes[0]);
        }
    }

