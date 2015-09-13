using System;
class BonusScore
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("What's your score[1-9]");
            double score = double.Parse(Console.ReadLine());
            if (score > 0 && score <= 3)
            {
                score = score * 10;
                Console.WriteLine("Your score is {0}", score);
            }
            else if (score > 3 && score <= 6)
            {
                score = score * 100;
                Console.WriteLine("Your score is {0}", score);
            }
            else if (score > 6 && score <= 9)
            {
                score = score * 1000;
                Console.WriteLine("Your score is {0}", score);
            }
            else
            {
                Console.WriteLine("Invalid score!");
            }
        }
    }
}