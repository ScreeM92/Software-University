using System;

public class Program
{
    public static void Main()
    {

        int judge = int.Parse(Console.ReadLine());

        int[] cats = new int[11];

        for (int i = 0; i < judge; i++)
        {
            int mark = int.Parse(Console.ReadLine());
            cats[mark]++;
        }

        int max = 0;
        int result = 0;
        for (int i = 1; i < cats.Length; i++)
        {
            int currentValue = cats[i];

            if (max < currentValue)
            {
                max = currentValue;
                result = i;
            }
        }
        Console.WriteLine(result);


        //2-ri variant
        //int n = int.Parse(Console.ReadLine());
        //int[] cats = new int[n];
        //for (int i = 0; i < n; i++)
        //{
        //    cats[i] = int.Parse(Console.ReadLine());
        //}
        //Array.Sort(cats);

        //int votes = 0;
        //int winner = 0;
        //int counter = 1;
        //for (int i = 0; i < n - 1; i++)
        //{
        //    if (cats[i] == cats[i + 1])
        //    {
        //        counter++;
        //        if (votes < counter)
        //        {
        //            votes = counter;
        //            winner = cats[i];
        //        }
        //    }
        //    else
        //    {
        //        counter = 1;
        //    }
        //}
        //Console.WriteLine(winner);
    }

}