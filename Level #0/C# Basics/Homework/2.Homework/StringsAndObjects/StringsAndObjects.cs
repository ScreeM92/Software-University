using System;
    class StringsAndObjects
    {
        static void Main()
        {
            string hello = "Hello";
            string world = "World";
            object helloworld = hello + " " + world;
            string result = (string)helloworld; //string printhelloworld = helloworld.ToString();
            Console.WriteLine(result);//Console.WriteLine(printhelloworld);
        }
    }

