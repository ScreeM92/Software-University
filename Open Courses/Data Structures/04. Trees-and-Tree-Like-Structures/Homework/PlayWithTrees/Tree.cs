namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree
    {
        public Tree(int value, params Tree[] children)
        {
            this.Value = value;
            this.Children = new List<Tree>();

            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parrent = this;
            }
        }

        public int Value { get; set; }

        public IList<Tree> Children { get; private set; }

        public Tree Parrent { get; set; }

        public void Print(int indent = 0)
        {
            Console.Write(new string(' ', 2 * indent));
            Console.WriteLine(this.Value);
            foreach (var child in this.Children)
            {
                child.Print(indent + 1);
            }
        }

        public void Each(Action<int> action)
        {
            action(this.Value);
            foreach (var child in this.Children)
            {
                child.Each(action);
            }
        }

        public IList<int> FindLongestPath(Stack<int> currentPath = null, IList<int> longestPath = null)
        {
            if (currentPath == null)
            {
                currentPath = new Stack<int>();
                longestPath = new List<int>();
            }

            currentPath.Push(this.Value);
            

            foreach (var child in this.Children)
            {
                longestPath = child.FindLongestPath(currentPath, longestPath);
            }

            if (currentPath.Count > longestPath.Count)
            {
                longestPath = currentPath.ToList();
            }

            currentPath.Pop();

            return longestPath;
        }

        public IList<IList<int>> FindSumPath(int sum, int? currentSum = null, Stack<int> currentPath = null, IList<IList<int>> foundPaths = null)
        {
            if (currentPath == null)
            {
                currentPath = new Stack<int>();
                foundPaths = new List<IList<int>>();
                currentSum = 0;
            }

            currentPath.Push(this.Value);
            currentSum += this.Value;

            foreach (var child in this.Children)
            {
                foundPaths = child.FindSumPath(sum, currentSum, currentPath, foundPaths);
            }

            if (currentSum == sum)
            {
                var sumPath = currentPath.ToList();
                sumPath.Reverse();
                foundPaths.Add(sumPath);
            }

            currentPath.Pop();

            return foundPaths;
        }
    }
}