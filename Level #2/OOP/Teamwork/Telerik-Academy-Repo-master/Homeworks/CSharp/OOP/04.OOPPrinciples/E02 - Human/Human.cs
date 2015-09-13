using System;

internal abstract class Human
{
    public abstract string GetName();

    private string firstName;
    private string lastName;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new FormatException("Name must be least 3 symbols");   
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new FormatException("Name must be least 3 symbols");
            }
            this.lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}
