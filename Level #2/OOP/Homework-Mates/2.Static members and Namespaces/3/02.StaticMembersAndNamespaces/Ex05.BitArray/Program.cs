namespace Ex05.BitArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            BitArray bit = new BitArray(8);
            bit[7] = 1;
            Console.WriteLine(bit.ToString());
        }
    }
}
