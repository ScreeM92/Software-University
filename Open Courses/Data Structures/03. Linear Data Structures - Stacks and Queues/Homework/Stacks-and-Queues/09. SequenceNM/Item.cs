namespace _09.SequenceNM
{
    public class Item
    {
        public Item(int value, Item previousItem = null)
        {
            this.Value = value;
            this.PreviousItem = previousItem;
            this.SetDepth();
        }

        public int Depth { get; private set; }

        public int Value { get; private set; }

        public Item PreviousItem { get; set; }

        private void SetDepth()
        {
            this.Depth = this.PreviousItem != null ? this.PreviousItem.Depth + 1 : 1;
        }
    }
}