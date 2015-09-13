using System;
    class Program
    {

        public static void Main()
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
            Location mars = new Location(20, -160.8999, Planet.Mars);
            Console.WriteLine(mars);
            Location jupiter = new Location(10, 1010101222, Planet.Jupiter);
            Console.WriteLine(jupiter);
        }
    }

