using System;
using System.Collections.Generic;
    class TestClass
    {
        static void Main(string[] args)
        {
            Dog firstDog = new Dog(2, "Sharo");
            Dog secondDog = new Dog(6, "Djaro");
            Dog thirdDog = new Dog(1, "Tobi");
            Dog fourthDog = new Dog(5, "Roni");

            Dog[] dogs = new Dog[]
            {
                firstDog, secondDog, thirdDog, fourthDog
            };

            Console.WriteLine("The average age of the dogs is: {0}", Animal.GetAverageAge(dogs));
            firstDog.MakeSound();
            Console.WriteLine();

            Cat firstCat = new Kitten(1, "Kitty");
            Cat secondCat = new Tomcat(2, "Bojko");
            Cat thirdCat = new Cat(4, "Myrzel", "male");

            Cat[] cats = new Cat[] 
            {
                firstCat,
                secondCat,
                thirdCat
            };

            Console.WriteLine("The average age of the cats is: {0}", Animal.GetAverageAge(cats));
            Console.WriteLine();
            
            Console.WriteLine("The kitten's name is: {0} ", firstCat.GetName());
            Console.WriteLine("The kitten's age is: {0}", firstCat.GetAge());
            Console.WriteLine("All kittens are {0}", firstCat.Sex);
            firstCat.MakeSound();
            Console.WriteLine();

            Console.WriteLine("The tomcat's name is: {0}", secondCat.GetName());
            Console.WriteLine("All tomcats are {0}", secondCat.Sex);
            secondCat.MakeSound();

            thirdCat.MakeSound();
            Console.WriteLine();

            Frog froggy = new Frog(22, "Prince");
            froggy.MakeSound();

        }
    }
