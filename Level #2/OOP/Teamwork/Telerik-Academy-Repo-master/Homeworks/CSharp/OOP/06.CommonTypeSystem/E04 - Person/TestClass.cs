using System;

class TestClass
{
    static void Main(string[] args)
    {
        Person pesho = new Person("Pesho", 73);
        Console.WriteLine(pesho.ToString());
        Console.WriteLine();

        Person ivo = new Person("Ivo");
        Console.WriteLine(ivo.ToString());
    }
}