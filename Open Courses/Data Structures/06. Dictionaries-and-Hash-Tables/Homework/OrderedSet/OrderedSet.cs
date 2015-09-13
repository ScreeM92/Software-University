namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private OrderedSetNode<T> root; 

        public OrderedSet()
        {
            this.Count = 0;
            this.root = null;
        }

        public int Count { get; set; }

        public T Min
        {
            get { return this.FindMin(); }
        }

        public T Max
        {
            get { return this.FindMax(); }
        }

        public bool Add(T element)
        {
            if (!this.Contains(element))
            {
                this.AddValue(element, null, this.root);
                return true;
            }

            return false;
        }

        public bool Remove(T element)
        {
            var node = this.NodeByValue(element);
            
            if (node != null)
            {
                this.Reorder(node);
                this.Count--;
                return true;
            }

            return false;
        }

        public OrderedSetNode<T> NodeByValue(T element)
        {
            var currentNode = this.root;

            while (currentNode != null)
            {
                int comparison = element.CompareTo(currentNode.Item);

                if (comparison < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (comparison > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        } 

        public bool Contains(T element)
        {
            if (this.root != null)
            {
                foreach (var node in this.root)
                {
                    if (node.Equals(element))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void ForEach(Action<T> action)
        {
            if (this.root != null)
            {
                this.root.EachInOrder(action);
            }
        }

        public void Clear()
        {
            this.root = null;
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The set is empty!");
            }

            return this.root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Reorder(OrderedSetNode<T> node)
        {
            if (node.Right != null && node.Left != null)
            {
                var right = node.Right;
                while (right.Left != null)
                {
                    right = right.Left;
                }

                right.Left = node.Left;
                right.Left.Parent = right;
                this.SetParent(node, node.Right);
                node = node.Right;
            }
            else if (node.Right != null || node.Left != null)
            {
                var newNode = node.Right ?? node.Left;
                this.SetParent(node, newNode);
                node = newNode;
            }
            else
            {
                this.SetParent(node, null);
            }
        }

        private void SetParent(OrderedSetNode<T> node, OrderedSetNode<T> newNode)
        {
            if (node.Parent != null)
            {
                if (node.Parent.Right == node)
                {
                    node.Parent.Right = newNode;
                }
                else
                {
                    node.Parent.Left = newNode;
                }

                if (newNode != null)
                {
                    newNode.Parent = node.Parent;
                }
            }
            else
            {
                this.root = newNode;
                if (newNode != null)
                {
                    newNode.Parent = null;
                }
            }
        }

        private OrderedSetNode<T> AddValue(T element, OrderedSetNode<T> parent, OrderedSetNode<T> node)
        {
            if (node == null)
            {
                node = new OrderedSetNode<T>(element) { Parent = parent };
                this.root = this.root ?? node;
                this.Count++;
            }
            else
            {
                var comparison = element.CompareTo(node.Item);
                if (comparison < 0)
                {
                    node.Left = this.AddValue(element, node, node.Left);
                }
                else
                {
                    node.Right = this.AddValue(element, node, node.Right);
                }
            }

            return node;
        }

        private T FindMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The set is empty!");
            }

            var currentNode = this.root;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode.Item;
        }

        private T FindMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The set is empty!");
            }

            var currentNode = this.root;
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }

            return currentNode.Item;
        }
    }
}