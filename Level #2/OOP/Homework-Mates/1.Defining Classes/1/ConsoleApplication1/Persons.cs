using System;

public class Persons
{
    private string name;
    private int age;
    private string email;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value != null)
            {
                this.name = value;
            }
            else
            {
                throw new ArgumentNullException("Name can't be NULL or empty!");
            }
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value > 0 && value < 100)
            {
                this.age = value;
            }
            else
            {
                throw new Exception("Age can be in range [ 0 ... 100 ]");
            }
        }
    }
    public string Email
    {
        get { return this.email; }
        set
        {
            //if (value == null)
            //{
            //    this.email = value;
            //}
            //else
            //{
            //    if (value.Contains("@"))
            //    {
            //        this.email = value;
            //    }
            //    else
            //    {
            //        throw new Exception("Invalide email!");
            //    }
            //}

            if (value != null && value.Contains("@"))
            {
                this.email = value;
            }
            else
            {
                 throw new Exception("Invalide email!");
            }
        }
    }

    public Persons(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Persons(string name, int age, string email = null)
    {
        Name = name;
        Age = age;
        Email = email;
    }

    public override string ToString()
    {
        return string.Format("Name: {0}, Age: {1}, Email {2}", Name, Age, Email);
    }
}

