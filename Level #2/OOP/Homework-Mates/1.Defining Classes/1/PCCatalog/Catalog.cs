using System;
using System.Collections.Generic;
using System.Linq;
    class Catalog
    {
        static void Main() {
            List<Computer> computers = new List<Computer>();
            
            List<Component> components = new List<Component>();
            components.Add(new Component("Процесор", "Intel Core i7-4700HQ", 533.50m));
            components.Add(new Component("Памет", "12GB DDR3, 1600Mhz", 120m));
            components.Add(new Component("Видео карта", "NVIDIA GeForce (4GB DDR3)", 320m));
            components.Add(new Component("Диск", "1TB HDD (7200 оборота/минута)", 170m));
            components.Add(new Component("Екран", "15.6h  1920x1080 (Full HD) IPS, матов", 89.99m));
            components.Add(new Component("Оптично устройство", "DVD записвачка", 32m));
            components.Add(new Component("Свързаност", "LAN 802.11а/g/n, Bluetooth 4.0", 109m));

            computers.Add(new Computer("ASUS ROG G550JK-CN268D", components));
            components.Clear();

            components.Add(new Component("Процесор", "Intel Core i7-4700HQ", 455.50m));
            components.Add(new Component("Памет", "12GB DDR3, 1600Mhz", 120m));
            components.Add(new Component("Видео карта", "NVIDIA GeForce (4GB DDR3)", 320m));
            components.Add(new Component("Диск", "1TB HDD (7200 оборота/минута)", 170m));
            components.Add(new Component("Екран", "15.6h  1920x1080 (Full HD) IPS, матов", 89.99m));
            components.Add(new Component("Оптично устройство", "DVD записвачка", 32m));
            components.Add(new Component("Свързаност", "LAN 802.11а/g/n, Bluetooth 4.0", 109m));

            computers.Add(new Computer("ACER ROG G550JK-CN268D", components));
            components.Clear();
            components.Add(new Component("Процесор", "Intel Core i7-4700HQ", 600.50m));
            components.Add(new Component("Памет", "12GB DDR3, 1600Mhz", 120m));
            components.Add(new Component("Видео карта", "NVIDIA GeForce (4GB DDR3)", 320m));
            components.Add(new Component("Диск", "1TB HDD (7200 оборота/минута)", 170m));
            components.Add(new Component("Екран", "15.6h  1920x1080 (Full HD) IPS, матов", 89.99m));
            components.Add(new Component("Оптично устройство", "DVD записвачка", 32m));
            components.Add(new Component("Свързаност", "LAN 802.11а/g/n, Bluetooth 4.0", 109m));

            computers.Add(new Computer("Lenovo ROG G550JK-CN268D", components));
            components.Clear();

            components.Add(new Component("Процесор", "Intel Core i7-4700HQ", 522.50m));
            components.Add(new Component("Памет", "12GB DDR3, 1600Mhz", 120m));
            components.Add(new Component("Видео карта", "NVIDIA GeForce (4GB DDR3)", 320m));
            components.Add(new Component("Диск", "1TB HDD (7200 оборота/минута)", 170m));
            components.Add(new Component("Екран", "15.6h  1920x1080 (Full HD) IPS, матов", 89.99m));
            components.Add(new Component("Оптично устройство", "DVD записвачка", 32m));
            components.Add(new Component("Свързаност", "LAN 802.11а/g/n, Bluetooth 4.0", 109m));

            computers.Add(new Computer("HP ROG G550JK-CN268D", components));
            components.Clear();


            var sortedList = computers.OrderBy(q => q.Price).ToList();
            foreach (Computer pc in sortedList)
            {
                Console.WriteLine( pc.ToString());
            }
        }

    }
