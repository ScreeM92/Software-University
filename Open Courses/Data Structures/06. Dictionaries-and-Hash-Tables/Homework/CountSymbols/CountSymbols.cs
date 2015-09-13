namespace CountSymbols
{
    using System;
    using System.Linq;
    using Dictionary;

    public class CountSymbols
    {
        public static void Main()
        {
            var chars = Console.ReadLine().ToCharArray();
            var symbols = new Dictionary<char, int>();
            
            foreach (var c in chars)
            {
                if (!symbols.ContainsKey(c))
                {
                    symbols[c] = 0;
                }

                symbols[c]++;
            }

            symbols.OrderBy(c => c.Key)
                .ToList()
                .ForEach(c => { Console.WriteLine("{0}: {1} time/s", c.Key, c.Value); });
        }
    }
}