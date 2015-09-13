namespace Diablo.Data
{
    using System;
    using System.Linq;

    public class DiabloMain
    {
        public static void Main()
        {
            var context = new DiabloEntities();
            context.Characters.Select(c => c.Name).ToList().ForEach(Console.WriteLine);
        }
    }
}