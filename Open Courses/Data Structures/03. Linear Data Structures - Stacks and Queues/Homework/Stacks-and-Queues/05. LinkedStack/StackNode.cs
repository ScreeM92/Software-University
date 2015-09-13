namespace _05.LinkedStack
{
    internal class StackNode<T>
    {
        public StackNode(T value, StackNode<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public T Value { get; private set; }

        public StackNode<T> NextNode { get; set; }
    }
}