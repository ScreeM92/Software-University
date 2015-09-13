namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayWithTrees
    {
        static readonly Dictionary<int, Tree> NodeByValue = new Dictionary<int, Tree>();
        static readonly string Separator = new string('-', 70);


        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < nodesCount - 1; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parrent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            PrintResults(pathSum, subtreeSum);
        }

        private static void PrintResults(int pathSum, int subtreeSum)
        {
            Console.WriteLine("{0}\nRoot node: {1}\n{0}", Separator, FindRootNode().Value);

            Console.WriteLine("Leaf nodes: {0}\n{1}", string.Join(", ", FindLeafNodes().Select(n => n.Value)), Separator);

            Console.WriteLine("Middle nodes: {0}\n{1}", string.Join(", ", FindMiddleNodes().Select(n => n.Value)), Separator);

            var longestPath = FindLongestPath();
            Console.WriteLine("Longest path:\n{0} (length = {1})\n{2}", string.Join(" -> ", longestPath), longestPath.Count, Separator);

            var sumPaths = FindSumPath(pathSum);
            Console.WriteLine("Paths of sum {0}:", pathSum);
            foreach (var sumPath in sumPaths)
            {
                Console.WriteLine(string.Join(" -> ", sumPath));
            }

            Console.WriteLine(Separator);
        }

        public static Tree GetTreeNodeByValue(int value)
        {
            if (!NodeByValue.ContainsKey(value))
            {
                NodeByValue[value] = new Tree(value);
            }

            return NodeByValue[value];
        }

        public static Tree FindRootNode()
        {
            var rootNode = NodeByValue.Values.FirstOrDefault(n => n.Parrent == null);

            return rootNode;
        }

        public static IEnumerable<Tree> FindMiddleNodes()
        {
            var middleNodes = NodeByValue.Values.OrderBy(n => n.Value).Where(n => n.Children.Any() && n.Parrent != null);

            return middleNodes;
        } 

        public static IEnumerable<Tree> FindLeafNodes()
        {
            var middleNodes = NodeByValue.Values.OrderBy(n => n.Value).Where(n => !n.Children.Any() && n.Parrent != null);

            return middleNodes;
        }

        public static IList<int> FindLongestPath()
        {
            var rootNode = FindRootNode();
            var longest = rootNode.FindLongestPath();
            longest.Reverse();

            return longest;
        }

        public static IList<IList<int>> FindSumPath(int sum)
        {
            var rootNode = FindRootNode();
            var sumPaths = rootNode.FindSumPath(sum);
            
            return sumPaths;
        }
    }
}