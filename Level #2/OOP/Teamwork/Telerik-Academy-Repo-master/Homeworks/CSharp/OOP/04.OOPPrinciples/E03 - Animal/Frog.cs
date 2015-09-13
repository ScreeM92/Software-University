using System;

class Frog : Animal, ISound
{
    public Frog(string name) : base(name) { }
    public Frog(int age, string name) : base(age, name) { }
    public Frog(int age, string name, string sex) : base(age, name, sex) { }
    
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
        Console.WriteLine("The {0}s make Kvak", this.ToString().ToLower());
    }
}
