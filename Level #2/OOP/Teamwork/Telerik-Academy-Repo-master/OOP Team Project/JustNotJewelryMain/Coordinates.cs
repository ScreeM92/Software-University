using System;
using System.Linq;

namespace JustNotJewelryMain
{
    public struct Coordinates
    {
        private int row;
        private int col;

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        public Coordinates(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                throw new ArgumentOutOfRangeException("The row must be non-negative");
            }
            this.row = row;
            this.col = col;
        }

        public static Coordinates operator +(Coordinates firstObj, Coordinates secondObj)
        {
            return new Coordinates((firstObj.Row + secondObj.Row), (firstObj.Col + secondObj.Col));
        }

        public static Coordinates operator ++(Coordinates obj)
        {
            return new Coordinates(++obj.Row, ++obj.Col);
        }
    }
}
