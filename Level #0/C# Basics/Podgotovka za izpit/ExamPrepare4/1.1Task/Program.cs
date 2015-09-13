using System;
    class Program
    {
        static void Main()
        {
            //Telerik Academy Exam 1 @ 24 June 2013 Evening
            decimal tomatoPrice = 0.5m;
            decimal cucumberPrice = 0.4m;
            decimal potatoPrice = 0.25m;
            decimal carrotPrice = 0.6m;
            decimal cabbagePrice = 0.3m;
            decimal beansPrice = 0.4m;
            decimal totalArea = 250m;

            decimal tomatoSeeds = decimal.Parse(Console.ReadLine());
            decimal tomatoArea = decimal.Parse(Console.ReadLine());
            decimal cucumberSeeds = decimal.Parse(Console.ReadLine());
            decimal cucumberArea = decimal.Parse(Console.ReadLine());
            decimal potatoesSeeds = decimal.Parse(Console.ReadLine());
            decimal potatoesArea = decimal.Parse(Console.ReadLine());
            decimal carrotSeeds = decimal.Parse(Console.ReadLine());
            decimal carrotArea = decimal.Parse(Console.ReadLine());
            decimal cabbagetSeeds = decimal.Parse(Console.ReadLine());
            decimal cabbageArea = decimal.Parse(Console.ReadLine());

            decimal beansSeeds = decimal.Parse(Console.ReadLine());

            decimal totalPrice = tomatoSeeds * tomatoPrice + cucumberSeeds * cucumberPrice + potatoesSeeds * potatoPrice + carrotSeeds * carrotPrice + cabbagetSeeds * carrotPrice + beansSeeds * beansPrice;
            Console.WriteLine("Total price: {0:F2}", tomatoPrice);

            decimal beansArea = totalArea - tomatoArea - cucumberArea - potatoesArea - carrotArea - cabbageArea;

            if (beansArea > 0)
            {
                Console.WriteLine("Beans area: {0}", beansArea);
            }
            else if (beansArea == 0)
            {
                Console.WriteLine("No area for beans");
            }
            else
            {
                Console.WriteLine("Insufficient area");
            }
        }
    }

