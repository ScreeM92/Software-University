using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Customer
{
    class CustomerMain
    {
        static void Main()
        {
            Customer lili = new Customer(
                "Lili",
                "Kalapova",
                "Bonin",
                1234567,
                "Plovdiv",
                "4567456",
                "lili@abv.bg",
                new List<Payment>() { new Payment("Lenovo laptop", 850) },
                CustomerType.OneTime);

            Customer gosho = new Customer(
                "Gosho",
                "Kostadinov",
                "Kalapov",
                9876543,
                "Luisville",
                "09017654",
                "gosho@abv.bg",
                new List<Payment>() { new Payment("Calculator", 50), new Payment("Mouse Pad", 13), new Payment("Mic", 6) },
                CustomerType.Regular);

            Customer emo = new Customer(
                "Emil",
                "Georgiev",
                "Georgiev",
                5454590,
                "Sofia",
                "08983334",
                "emo@abv.bg",
                new List<Payment>() { new Payment("Server", 2850) },
                CustomerType.Golden);

            var liliCopy = lili;
            lili.Payments.Add(new Payment("mouse", 12));
            lili.LastName = "kalapova-bonin";
            Console.WriteLine(lili);
            Console.WriteLine(liliCopy);
            Console.WriteLine(liliCopy == lili);
            Console.WriteLine(lili.Equals(liliCopy));

            var liliClone = (Customer)lili.Clone();
            Console.WriteLine(lili == gosho);
            Console.WriteLine(lili == liliClone);
            Console.WriteLine(lili == liliCopy);

            Console.WriteLine(lili.CompareTo(gosho));
            Console.WriteLine(emo.CompareTo(lili));
            Console.WriteLine(lili.CompareTo(liliClone));

        }
    }
}
