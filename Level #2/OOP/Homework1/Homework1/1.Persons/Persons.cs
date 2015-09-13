using System;

class Persons
{
    static void Main()
    {
        Console.WriteLine("Enter name");
        string name1 = Console.ReadLine();

        Console.WriteLine("Enter age");
        int age1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter email");
        string email1 = Console.ReadLine();

        Person person1 = new Person(name1, age1, email1);

        Console.WriteLine("Name: {0}, Age: {1}", person1.Name, person1.Age + (person1.Email == "" ? "" : ", Email: " + person1.Email));
        //Console.WriteLine(person1);
    }
}