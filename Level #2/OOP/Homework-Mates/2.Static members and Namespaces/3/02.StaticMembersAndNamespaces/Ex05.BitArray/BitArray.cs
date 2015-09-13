namespace Ex05.BitArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class BitArray
    {
        private byte[] bits;

        public BitArray(int bitsLentgth)
        {
            if (bitsLentgth < 1 || bitsLentgth > 100000)
            {
                throw new IndexOutOfRangeException("Bits length is between 1 and 100000");
            }

            this.bits = new byte[bitsLentgth];
        }

        public byte this[int index]
        {
            get
            {
                if (index < 1 && index > this.bits.Length - 1)
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                return this.bits[index];
            }

            set
            {
                if (index < 1 && index > this.bits.Length - 1)
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Value must be 0 or 1");
                }

                this.bits[index] = value;
            }
        }

        public override string ToString()
        {
            BigInteger number = 0;

            for (int i = 0; i < this.bits.Length; i++)
            {
                if (this.bits[i] == 1)
                {
                    number += BigInteger.Pow(2, i);
                }
            }

            return number.ToString();
        }
    }
}
