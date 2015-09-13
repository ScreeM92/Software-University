using System;

class Cat : Animal, ISound
{

    public Cat(string name) : base(name) { }
    public Cat(int age, string name) : base(age, name) { }
    public Cat(int age, string name, string sex) : base(age, name, sex) { }


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
        Console.WriteLine("The {0}s make Mquuu", this.ToString().ToLower());
    }
}
