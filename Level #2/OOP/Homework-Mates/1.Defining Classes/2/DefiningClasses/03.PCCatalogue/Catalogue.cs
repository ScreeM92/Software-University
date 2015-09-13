using System;
using System.Collections.Generic;

namespace PCCatalogue
{
    class Catalogue
    {
        static void Main(string[] args)
        {
            List<Component> comp1components = new List<Component>();
            comp1components.Add(new Component("Processor", (decimal)432.45, "INTEL I5 3.5 GHz"));
            comp1components.Add(new Component("RAM", (decimal)111.21, "Corsair Vengence 8 GB"));
            comp1components.Add(new Component("Motherboard", (decimal)156.78, "Assus"));
            comp1components.Add(new Component("Graphics Card", (decimal)678.00, "Radeon Sapphire HD7895"));
            comp1components.Add(new Component("HDD", (decimal)110.12, "Western Digital 500GB"));
            comp1components.Add(new Component("Power Supply", (decimal)250.48, "Cooler Master 650W Gold"));
            comp1components.Add(new Component("Case", (decimal)290.00, "CM Strom Trooper"));
            Computer comp1 = new Computer("Gaming Build", comp1components);

            List<Component> comp2components = new List<Component>();
            comp2components.Add(new Component("Processor", (decimal)785.35, "INTEL I7 3.1 GHz"));
            comp2components.Add(new Component("RAM", (decimal)230.57, "Corsair Vengence 16 GB"));
            comp2components.Add(new Component("Motherboard", (decimal)156.78, "Assus"));
            comp2components.Add(new Component("Graphics Card", (decimal)678.01, "Radeon Sapphire HD7895"));
            comp2components.Add(new Component("HDD", (decimal)350.12, "Sony 1TB SSD"));
            comp2components.Add(new Component("Power Supply", (decimal)635.78, "Cooler Master 1500W Gold"));
            comp2components.Add(new Component("Case", (decimal)290.00, "CM Strom Trooper"));
            Computer comp2 = new Computer("Ulta PC", comp2components);

            List<Component> comp3components = new List<Component>();
            comp3components.Add(new Component("Processor", (decimal)56.5, "INTEL Pentium 3"));
            comp3components.Add(new Component("RAM", (decimal)8.49, "Kingston 512MB"));
            comp3components.Add(new Component("Motherboard", (decimal)12.8, "Assus"));
            comp3components.Add(new Component("Graphics Card", (decimal)150.78, "ATI Radeon HD3580"));
            comp3components.Add(new Component("HDD", (decimal)48.99, "Sony 200GB"));
            comp3components.Add(new Component("Power Supply", (decimal)55.55, "200W"));
            comp3components.Add(new Component("Case", (decimal)17.2, "Classic White Case"));
            Computer comp3 = new Computer("PC fourth hand", comp3components);

            List<Computer> computersList = new List<Computer>();
            computersList.Add(comp1);
            computersList.Add(comp2);
            computersList.Add(comp3);

            computersList.Sort();

            foreach (Computer computer in computersList)
            {
                Console.WriteLine(computer.Display());
            }
        }
    }
}
