using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Location home = new Location(18.037986, 28.870097, Planet.Earth);
        Console.WriteLine(home);
    }
}
