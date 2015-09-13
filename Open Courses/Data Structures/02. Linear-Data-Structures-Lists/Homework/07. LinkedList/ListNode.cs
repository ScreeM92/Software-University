namespace _07.LinkedList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }
    }
}