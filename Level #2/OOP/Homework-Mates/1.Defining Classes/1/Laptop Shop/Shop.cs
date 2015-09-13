using System;

public class Shop
{
    static void Main()
    {
        Battery battery = new Battery();
        Laptop Laptop = new Laptop("Pro 720", "Asus", "Intel i7 4.1 GHz", "4GB KINGSTON", "NVidia GForce 2GB", "500 TB", "15.6h", battery, 1000, 2000m);
        Console.WriteLine(Laptop.ToString());

        Console.WriteLine("-----------------");

        Laptop OtherLaptop = new Laptop("Satelite PRO", 1248.00m);
        Console.WriteLine(OtherLaptop.ToString());
    }
}
