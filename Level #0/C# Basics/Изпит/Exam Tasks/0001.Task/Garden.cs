using System;
    class Garden
    {
        static void Main()
        {
            int tomatoSeeds = int.Parse(Console.ReadLine());
            int tomatoArea = int.Parse(Console.ReadLine());
            int cucumberSeeds = int.Parse(Console.ReadLine());
            int cucumberArea = int.Parse(Console.ReadLine());
            int potatoSeeds = int.Parse(Console.ReadLine());
            int potatoArea = int.Parse(Console.ReadLine());
            int carrotSeeds = int.Parse(Console.ReadLine());
            int carrotArea = int.Parse(Console.ReadLine());
            int cabbageSeeds = int.Parse(Console.ReadLine());
            int cabbageArea = int.Parse(Console.ReadLine());
            int beansSeeds = int.Parse(Console.ReadLine());

            decimal tomatoPrice = 0.5m;
            decimal cucumberPrice = 0.4m;
            decimal potatoPrice = 0.25m;
            decimal carrotPrice = 0.6m;
            decimal cabbagePrice = 0.3m;
            decimal beansPrice = 0.4m;

            int area = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;
            int beansArea;

            decimal total = tomatoSeeds * tomatoPrice + cucumberSeeds * cucumberPrice + potatoSeeds * potatoPrice + carrotSeeds * carrotPrice + cabbageSeeds * cabbagePrice + beansPrice * beansSeeds;
            Console.WriteLine("Total costs: {0:F2}", total);
            if (area == 250)
            {
                Console.WriteLine("No area for beans");
            }
            else if (area > 250)
            {
                Console.WriteLine("Insufficient area");
            }
            else if (area <= 250)
            {
                beansArea = 250 - area;
                Console.WriteLine("Beans area: {0}", beansArea);
            }
        }
    }

