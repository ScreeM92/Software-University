using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.ConsoleClient
{
    public class Menu
    {
        private SortedDictionary<string, Action> menuItems;
        private SortedDictionary<string, string> menuLabels;
        private string endKey;

        public Menu()
        {
            this.menuItems = new SortedDictionary<string, Action>();
            this.menuLabels = new SortedDictionary<string, string>();
        }

        public void AddItem(string key, string label, Action action) 
        {
            this.menuItems.Add(key, action);
            this.menuLabels.Add(key, label);
        }

        public void AddEndItem(string key, string label)
        {
            this.AddItem(key, label, null);
            this.endKey = key;
        }

        public void Start()
        {
            while (true)
            {
                foreach (var pair in menuLabels)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }

                Console.WriteLine();
                Console.Write("Enter your choice: ");

                string userInput = Console.ReadLine();

                if (userInput == endKey)
                {
                    Console.WriteLine("Exiting..");
                    return;
                }

                if (this.menuItems.ContainsKey(userInput))
                {
                    this.menuItems[userInput]();
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }
            }
        }
    }
}
