using System;
using System.Linq;
using System.Collections.Generic;

    class Test
    {
        static void Main()
        {
            Components mcardVLC = new MotherBoard("VLC", (decimal)185.98);
            Components vcardRadeon = new GraphicsCard("Radeon", (decimal)102.34, "the best grafic card forever");
            Components vcardGeForce = new GraphicsCard("GeForce", (decimal)154.45, "is not worth");

            Components procIntel = new Processor("Intel", (decimal)346.563, "can be better");
            Components procAMD = new Processor("AMD", (decimal)405.239, "always the best");
            Components procMac = new Processor("IOS", 2000m, "It is okaaaay");

            Computer mac = new Computer("Mac", new List<Components>() { mcardVLC, vcardRadeon, vcardGeForce });
            Computer windows = new Computer("Windows");
            windows.Components.Add(procIntel);
            windows.Components.Add(procAMD);
            windows.Components.Add(procMac);
            //Console.WriteLine(windows);

            Computer linux = new Computer("Linux", new List<Components>() { mcardVLC, vcardGeForce, vcardRadeon, procAMD, procIntel, procMac });

            List<Computer> computers = new List<Computer>() { mac, windows, linux };

            computers.OrderBy(p => p.TotalPrice).ToList().ForEach(p => Console.WriteLine(p.ToString()));


            //or

            //computers.OrderBy(a => a.TotalPrice);

            //foreach (var computer in computers)
            //{
            //    Console.WriteLine(computer);
            //}
        }
    }

