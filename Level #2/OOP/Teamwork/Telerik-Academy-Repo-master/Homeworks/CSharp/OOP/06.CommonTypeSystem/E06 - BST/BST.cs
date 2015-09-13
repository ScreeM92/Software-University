using System;
class BST 
{
    static void Main(string[] args)
    {
        BinaryTree<int> firstTree = new BinaryTree<int>();
        firstTree.AddNode(13);
        firstTree.AddNode(5);
        firstTree.AddNode(12);
        firstTree.AddNode(14);
        firstTree.AddNode(18);
        firstTree.AddNode(15);
        firstTree.AddNode(19);
        firstTree.AddNode(20);
        firstTree.AddNode(13);
        firstTree.AddNode(22);
        firstTree.AddNode(14);
        firstTree.AddNode(18);
        firstTree.AddNode(15);
        firstTree.AddNode(19);
        firstTree.AddNode(20);
        firstTree.AddNode(13);
        firstTree.AddNode(22);

        Console.WriteLine("The first tree - ToString()");
        Console.WriteLine(firstTree.ToString());
        Console.WriteLine();

        BinaryTree<int> secondTree = new BinaryTree<int>();
        secondTree.AddNode(13);
        secondTree.AddNode(5);
        secondTree.AddNode(12);
        secondTree.AddNode(14);
        secondTree.AddNode(18);
        secondTree.AddNode(15);
        secondTree.AddNode(19);
        secondTree.AddNode(20);
        secondTree.AddNode(13);
        secondTree.AddNode(22);

        Console.WriteLine("The second tree - foreach");
        foreach (var node in secondTree)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();
        Console.WriteLine();
        
        secondTree.DeleteElement(18);
        secondTree.DeleteElement(5);
        secondTree.DeleteElement(12);
        secondTree.DeleteElement(22);
        secondTree.DeleteElement(14);

        Console.WriteLine("The second tree after deleting elements - ToString()");
        Console.WriteLine(secondTree.ToString());
        Console.WriteLine();
        
        //Cloning demonstation
        BinaryTree<int> thirdTree = secondTree.Clone();
        Console.WriteLine("The third tree - ToString()");
        Console.WriteLine(thirdTree.ToString());
        Console.WriteLine();

        if (firstTree != thirdTree)
        {
            Console.WriteLine("The trees are NOT equal!");
        }
        Console.WriteLine();

        if (secondTree.Equals(thirdTree))
        {
            Console.WriteLine("The trees are equal!");
        }
        Console.WriteLine();

        //Search method demonstration - returns bool value
        Console.WriteLine("Found? {0}", thirdTree.Search(23));
        Console.WriteLine("Found? {0}", thirdTree.Search(20));
        Console.WriteLine("Found? {0}", firstTree.Search(-2220));
        Console.WriteLine("Found? {0}", secondTree.Search(1387));
        Console.WriteLine("Found? {0}", firstTree.Search(5));
        Console.WriteLine();

        //---------------------------------------------------------
        //Also we can create the tree using directly the constructor

        BinaryTree<string> fourthTree = new BinaryTree<string>("Hi", new BinaryTree<string>("there", new BinaryTree<string>("mate"), new BinaryTree<string>("What's")), new BinaryTree<string>("up"));
        Console.WriteLine("Fourth tree - ToString()");
        Console.WriteLine(fourthTree.ToString());
    }
}

