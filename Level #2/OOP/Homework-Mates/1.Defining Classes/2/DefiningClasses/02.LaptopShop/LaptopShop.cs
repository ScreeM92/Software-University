using System;

namespace Laptop
{
    class LaptopShop
    {
        static void Main(string[] args)
        {
            Battery lion = new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5);
            Laptop laptop1 = new Laptop("Lenovo Yoga 2 Pro", (decimal)2259.00, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "128GB SSD", "Intel HD Graphics 4400", lion, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");
            Laptop laptop2 = new Laptop("Acer Aspire V5", (decimal)1549.99);

            Console.WriteLine(laptop1.ToString());
            Console.WriteLine(laptop2.ToString());
        }
    }
}
