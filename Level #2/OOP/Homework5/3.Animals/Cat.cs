using System;

//public class Cat : Animal
//{
//    public Cat(string name, int age, Genter genter)
//        : base(name, age, genter)
//    {
//    }

//    public override void ProduceSound()
//    {
//        Console.WriteLine("I meow.");
//    }
//}



public enum Gender
{
    Male,
    Female
}
public class Cat : Animal
{
    public Cat(string name, int age)
        : base(name, age)
    {
    }

    public Gender Gender { get; private set; }

    public override void ProduceSound()
    {
        Console.WriteLine("I meooooowww");
    }
}























