using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public BinaryHeap(T[] elements)
    {
        this.heap = new List<T>(elements);
        for (int i = this.heap.Count / 2; i >= 0; i--)
        {
            this.HeapifyDown(i);
        }
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMax()
    {
        var max = this.heap[0];
        this.heap[0] = this.heap[this.heap.Count - 1];
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        return max;
    }

    public T PeekMax()
    {
        var max = this.heap[0];
        return max;
    }

    public void Insert(T node)
    {
        this.heap.Add(node);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var left = 2 * i + 1;
        var right = 2 * i + 2;
        var largest = i;
        if (left < this.heap.Count &&
            this.heap[left].CompareTo(this.heap[largest]) > 0)
        {
            largest = left;
        }

        if (right < this.heap.Count &&
            this.heap[right].CompareTo(this.heap[largest]) > 0)
        {
            largest = right;
        }

        if (largest != i)
        {
            T old = this.heap[i];
            this.heap[i] = this.heap[largest];
            this.heap[largest] = old;
            this.HeapifyDown(largest);
        }
    }

    private void HeapifyUp(int i)
    {
        var parent = (i - 1) / 2;

        while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) > 0)
        {
            T old = this.heap[i];
            this.heap[i] = this.heap[parent];
            this.heap[parent] = old;

            i = parent;
            parent = (i - 1) / 2;
        }
    }
}