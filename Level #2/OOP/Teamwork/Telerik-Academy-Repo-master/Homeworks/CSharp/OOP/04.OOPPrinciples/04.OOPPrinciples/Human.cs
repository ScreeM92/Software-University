using System;

class Human
{
    private string name;

    public string Name
    {
        get
        { return this.name; }
        set
        {
            if (value.Length < 3 && value.Length > 60)
            {
                throw new FormatException("The name must be between 3 and 60 symbols");
            }
            this.name = value;
        }
    }

    protected Human(string name)
    {
        this.name = name;
    }
}
