using System;

public class Frog : Animal
{
    public Frog(string name, int age)
        : base(name, age)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("I yioook.");
    }
}



























