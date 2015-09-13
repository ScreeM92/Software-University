class Kitten : Cat
{
    public Kitten(string name, int age, Gender gender)
        : base(name, age)
    {
        gender = Gender.Female;
    }

    public override string ToString()
    {
        return string.Format("I am a female cat.");
    }
}


































