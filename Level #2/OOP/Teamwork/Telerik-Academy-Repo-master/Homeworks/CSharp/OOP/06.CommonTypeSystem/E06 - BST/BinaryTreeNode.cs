using System;

class BinaryTreeNode<T>
{
    public T value;

    public BinaryTreeNode<T> leftNode;
    public BinaryTreeNode<T> rightNode;

    public BinaryTreeNode() { }

    public BinaryTreeNode(T value)
    {
        this.value = value;
    }

    public BinaryTreeNode(T value, BinaryTreeNode<T> leftNode, BinaryTreeNode<T> rightNode)
    {
        this.value = value;
        this.leftNode = leftNode;
        this.rightNode = rightNode;
    }
}
