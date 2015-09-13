using System;

class Dog : Animal, ISound
{
    public Dog(string name) : base(name) { }
    public Dog(int age, string name) : base(age, name) { }
    public Dog(int age, string name, string sex) : base(age, name, sex) { }

    public override int GetAge()
    {
        return this.Age;
    }

    public override string GetName()
    {
        return this.Name;
    }

    public void MakeSound()
    {
        Console.WriteLine("The {0}s make Woof!", this.ToString().ToLower());
    }
}
