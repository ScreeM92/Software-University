using System;

    class Test
    {
        public static void Main()
        {
            var pesho = new Customer("Petar", "Ivanov", "Mitrev", 123789, "dolno tunkovo", "123123123", "pesho@peshp.bg");
            var pesho2 = new Customer("Petar", "Ivanov", "Mitrev", 123488, "dolno tunkovo", "123123123123", "pesho@pesho2.pesho2");
            var gosho = new Customer("Gosho", "Ivanov", "Shopov", 100000, "na maikasi putkata", "1-500-123123", "gosho@goshev.gosho");

            Payment[] payments =
            {
                new Payment("book", 25.5m),
                new Payment("phone", 250.89m),
                new Payment("tablet", 500),
                new Payment("phone", 250.89m),
                new Payment("tablet", 500)
            };

            foreach (var payment in payments)
            {
                pesho.AddPayment(payment);
                gosho.AddPayment(payment);
            }

            var petarCloning = (Customer)pesho.Clone();
            //Console.WriteLine(gosho);
            Console.WriteLine(pesho == gosho);
            Console.WriteLine(pesho == pesho2);
            Console.WriteLine(pesho == petarCloning);

            Console.WriteLine(pesho.CompareTo(gosho));
            Console.WriteLine(pesho2.CompareTo(pesho));
            Console.WriteLine(pesho.CompareTo(petarCloning));

            Console.WriteLine("=------------------------------------------");

            Customer cloning = (Customer)pesho.Clone();

            pesho.payments[0].Price = 200;
            cloning.payments[0].Price = 100000;

            Console.WriteLine("Pesho cloninig:\n{0}", cloning.payments[0].Price);
            Console.WriteLine("Pesho:\n{0}", pesho.payments[0].Price);
        }
    }

