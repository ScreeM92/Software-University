namespace FindTheRoot
{
    using System;
    using System.Linq;

    public class FindTheRoot
    {
        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());
            bool[] hasParent = new bool[nodesCount];

            for (int i = 0; i < edgesCount; i++)
            {
                var edge = Console.ReadLine().Split(' ');
                var child = int.Parse(edge[1]);
                hasParent[child] = true;
            }

            var parents = hasParent.Select((n, i) => new { index = i, value = n }).Where(n => !n.value).ToList();

            Console.WriteLine(new string('-', 60));
            if (parents.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (parents.Count == 1)
            {
                Console.WriteLine(parents[0].index);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }
    }
}