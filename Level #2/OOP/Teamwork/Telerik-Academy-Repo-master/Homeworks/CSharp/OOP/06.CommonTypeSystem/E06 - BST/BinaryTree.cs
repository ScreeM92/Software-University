using System;
using System.Collections;
using System.Collections.Generic;

class BinaryTree<T> : IEnumerable<T>, ICloneable
{
    private BinaryTreeNode<T> root;
    
    private List<T> traversedValues = new List<T>();
    private List<T> storeValuesInOrderForCloneAndCompare = new List<T>();
    
    private bool isFound = false;

    //Propertie
    public BinaryTreeNode<T> Root
    {
        get
        {
            return this.root;
        }
        private set
        {
            this.root = value;
        }
    }
    
    //Constructors
    public BinaryTree() { }

    public BinaryTree(T value, BinaryTree<T> leftNode, BinaryTree<T> rightNode)
    {
        BinaryTreeNode<T> left = leftNode.root;
        BinaryTreeNode<T> right = rightNode.root;
        this.root = new BinaryTreeNode<T>(value, left, right);
    }

    public BinaryTree(T value)
    {
        this.root = new BinaryTreeNode<T>(value);
    }

    /*Add new node in the tree
    *If the root is null create new root
    *Else use help method to find an empty node*/
    public void AddNode(T value)
    {
        if (this.root == null)
        {
            this.root = new BinaryTreeNode<T>(value);
        }
        else
        {
            InsertHelper(this.root, value);
        }
        storeValuesInOrderForCloneAndCompare.Add(value);
    }

    /*Help method for adding new node (AddNote())
     *If the value is smaller than the parent checks left node for empty node for the new child and put it there 
     *Else (if the value is bigger) do the same but from the right side*/
    private void InsertHelper(BinaryTreeNode<T> node, T value)
    {
        if ((dynamic)value < node.value)
        {
            if (node.leftNode == null)
            {
                node.leftNode = new BinaryTreeNode<T>(value);
            }
            else
            {
                InsertHelper(node.leftNode, value);
            }   
        }
        else //if((dynamic)value > node.value)
        {
            if (node.rightNode == null)
            {
                node.rightNode = new BinaryTreeNode<T>(value);
            }
            else
            {
                InsertHelper(node.rightNode, value);
            }
        }
    }

    /*Deleting element from the tree
    *Set the main root to null
    *Remove our value from the stored values list
    *Use RecreateTheTree() method*/
    public void DeleteElement(T value)
    {
        this.root = null;
        storeValuesInOrderForCloneAndCompare.Remove(value);
        RecreateTheTree();
    }

    /*Recreate the tree by
     *Put deep clone the list into new temp array
     *Clear the list with the values
     *Traverse the temp array and create new tree with the values that left*/
    private void RecreateTheTree()
    {   
        T[] tempStore = (T[])storeValuesInOrderForCloneAndCompare.ToArray().Clone();
        storeValuesInOrderForCloneAndCompare.Clear();
        for (int index = 0; index < tempStore.Length; index++)
        {
            AddNode(tempStore[index]);
        }
    }

    //Search method - return bool value - true if the item is found and false if it's not
    public bool Search(T value)
    {
        
        if (this.root.value == (dynamic)value)
        {
            return isFound = true;
        }
        else
        {
            DeepSearch(this.root, value);
        }
        return isFound;
    }

    //Helper for the search item - use the InsertHelper() algorithm to find if the item is in the tree
    private void DeepSearch(BinaryTreeNode<T> node, T value)
    {
        if (isFound)
        {
            return;
        }
        if (node == null)
        {
            return;
        }

        if ((dynamic)value < node.value)
        {
            if (node.leftNode == null)
            {
                return;
            }
            if (node.leftNode.value == (dynamic)value)
            {
                isFound = true;
                return;
            }
            else
            {
                DeepSearch(node.leftNode, value);
            }   
        }
        else //if((dynamic)value > node.value)
        {
            if (node.rightNode == null)
            {
                return;
            }
            if (node.rightNode.value == (dynamic)value)
            {
                isFound = true;
                return;
            }
            else
            {
                DeepSearch(node.rightNode, value);
            }
        }
        
    }

    //Implement enumartor - now we can work with foreach
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the generic version of the method
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        ClearAndTraverse();
        for (int i = 0; i < traversedValues.Count; i++)
        {
            yield return this.traversedValues[i];
        }
    }
  
    //Small method that clear the traversed tree and traverse it again
    private void ClearAndTraverse()
    {
        this.traversedValues.Clear();
        TraverseTree(this.root);
    }

    //Traverse the tree using DFS algorithm
    private void TraverseTree(BinaryTreeNode<T> root)
    {
        if (root == null)
        {
            return;
        }
        this.traversedValues.Add(root.value);
        
        TraverseTree(root.rightNode);
        TraverseTree(root.leftNode);
    }
    
    //Override ToString() to show human friendly message - in that case the traversed tree
    public override string ToString()
    {
        ClearAndTraverse();
        return string.Join(" ", traversedValues);
    }

    //Override Equals so that we can check if two trees are equal or not
    public override bool Equals(object obj)
    {    
        BinaryTree<T> newObject = (BinaryTree<T>)obj;
        if (this.storeValuesInOrderForCloneAndCompare.Count != newObject.storeValuesInOrderForCloneAndCompare.Count)
        {
            return false;
        }

        for (int i = 0; i < this.traversedValues.Count - 4; i++)
        {
            if (this.storeValuesInOrderForCloneAndCompare[i] != (dynamic)newObject.storeValuesInOrderForCloneAndCompare[i])
            {
                return false;
            }
        }
        return true;
    }

    //Override GetHashCode() to get unique code
    public override int GetHashCode()
    {
        return (this.root.value.GetHashCode() * 251) ^ this.root.leftNode.value.GetHashCode();
    }

    //Override == and != operators using our Equals() method
    public static bool operator ==(BinaryTree<T> firstTree, BinaryTree<T> secondTree)
    {
        return firstTree.Equals(secondTree);
    }

    public static bool operator !=(BinaryTree<T> firstTree, BinaryTree<T> secondTree)
    {
        return !firstTree.Equals(secondTree);
    }

    //Override Clone() method
    // Implicit interface implementation
    object ICloneable.Clone()
    {
        return this.Clone();
    }

    //The method Clone()
    public BinaryTree<T> Clone()
    {
        BinaryTree<T> cloning = new BinaryTree<T>();
        for (int index = 0; index < storeValuesInOrderForCloneAndCompare.Count; index++)
        {
            cloning.AddNode(storeValuesInOrderForCloneAndCompare[index]);
        }
        return cloning;
    }

}
