public class TomCat : Cat
{
    public TomCat(string name, int age, Gender gender)
        : base(name, age)
    {
        gender = Gender.Male;
    }

    public override string ToString()
    {
        return string.Format("I am a {0} cat.", (this.Gender.ToString().ToLower()));
    }
}





























