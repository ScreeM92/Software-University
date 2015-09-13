namespace RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoundDance
    {
        private static Dictionary<int, List<int>> childNodes;
        private static List<int> visited;
        private static Stack<int> currentPath;
        private static List<List<int>> longestPaths;
        
        public static void Main()
        {
            childNodes = new Dictionary<int, List<int>>();
            visited = new List<int>();
            longestPaths = new List<List<int>>();
            currentPath = new Stack<int>();

            var friendshipsCount = int.Parse(Console.ReadLine());
            var leader = int.Parse(Console.ReadLine());

            ProcessFriendships(friendshipsCount);
            DFS(leader, childNodes[leader]);

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Longest path items: {0}", longestPaths.First().Count);
            PrintLongestPaths();
        }

        public static void DFS(int nodeValue, List<int> node)
        {
            if (!visited.Contains(nodeValue))
            {
                currentPath.Push(nodeValue);
                visited.Add(nodeValue);

                foreach (var i in node)
                {
                    DFS(i, childNodes[i]);
                }

                if (longestPaths.Count == 0 || currentPath.Count > longestPaths.First().Count)
                {
                    longestPaths = new List<List<int>> { currentPath.ToList() };
                }
                else if(currentPath.Count == longestPaths.First().Count)
                {
                    longestPaths.Add(currentPath.ToList());
                }

                currentPath.Pop();
            }
        }

        private static void PrintLongestPaths()
        {
            foreach (var path in longestPaths)
            {
                path.Reverse();
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        private static void ProcessFriendships(int friendshipsCount)
        {
            for (int i = 0; i < friendshipsCount; i++)
            {
                var friendship = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (!childNodes.ContainsKey(friendship[0]))
                {
                    childNodes[friendship[0]] = new List<int>();
                }

                if (!childNodes.ContainsKey(friendship[1]))
                {
                    childNodes[friendship[1]] = new List<int>();
                }

                childNodes[friendship[0]].Add(friendship[1]);
                childNodes[friendship[1]].Add(friendship[0]);
            }
        }
    }
}