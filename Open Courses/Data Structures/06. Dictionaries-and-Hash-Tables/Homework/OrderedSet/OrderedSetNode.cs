namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSetNode<T> : IEnumerable<T>
    {
        public OrderedSetNode(T item, OrderedSetNode<T> left = null, OrderedSetNode<T> right = null)
        {
            this.Item = item;
            this.Left = left;
            this.Right = right;
        }

        public T Item { get; set; }

        public OrderedSetNode<T> Left { get; set; }

        public OrderedSetNode<T> Right { get; set; }

        public OrderedSetNode<T> Parent { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Left != null)
            {
                foreach (var left in this.Left)
                {
                    yield return left;
                }
            }

            yield return this.Item;

            if (this.Right != null)
            {
                foreach (var right in this.Right)
                {
                    yield return right;
                }  
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void EachInOrder(Action<T> action)
        {
            if (this.Left != null)
            {
                this.Left.EachInOrder(action);
            }

            action(this.Item);

            if (this.Right != null)
            {
                this.Right.EachInOrder(action);
            }
        }
    }
}