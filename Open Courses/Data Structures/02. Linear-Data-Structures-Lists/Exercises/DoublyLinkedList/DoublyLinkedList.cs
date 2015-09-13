using System;
using System.Collections;
using System.Collections.Generic;
using Double_Linked_List;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private ListNode<T> Head { get; set; }

    private ListNode<T> Tail { get; set; }

    public void AddFirst(T element)
    {
        var newHead = new ListNode<T>(element);

        if (this.Count == 0)
        {
            this.Head = this.Tail = newHead;
        }
        else
        {
            newHead.NextNode = this.Head;
            this.Head.PrevNode = newHead;
            this.Head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        var newTail = new ListNode<T>(element);

        if (this.Count == 0)
        {
            this.Tail = this.Head = newTail;
        }
        else
        {
            newTail.PrevNode = this.Tail;
            this.Tail.NextNode = newTail;
            this.Tail = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }
        
        var firstElement = this.Head.Value;
        this.Head = this.Head.NextNode;

        if (this.Head != null)
        {
            this.Head.PrevNode = null;
        }
        else
        {
            this.Tail = null;
        }

        this.Count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        var lastElement = this.Tail.Value;
        this.Tail = this.Tail.PrevNode;
        if (this.Tail != null)
        {
            this.Tail.NextNode = null;
        }
        else
        {
            this.Head = null;
        }

        this.Count--;
        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.Head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var arr = new T[this.Count];
        var currentNode = this.Head;
        var index = 0;

        while (currentNode != null)
        {
            arr[index++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return arr;
    }
}