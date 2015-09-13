namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExtensionsDemo
    {
        public static void Main(string[] args)
        {
            StringBuilder strb = new StringBuilder("I really like my name: Ginka, GINKA, GiNkA, gInKa, GInka, GINka");

            var substr = strb.Substring(2, 15);
            Console.WriteLine(substr);

            strb.RemoveText("ginka");
            Console.WriteLine(strb.ToString());

            var numbers = new List<double> { 2.34, 3.456, 0.2345 };
            var words = new List<string> { "abra", "kadabra" };
            strb.AppendAll(numbers);
            Console.WriteLine(strb);
            strb.AppendAll(words);
            Console.WriteLine(strb);
        }
    }
}
