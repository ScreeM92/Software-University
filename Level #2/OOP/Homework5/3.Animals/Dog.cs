using System;

public class Dog : Animal
{
    public Dog(string name, int age)
        : base(name, age)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("I bark.");
    }
}




























