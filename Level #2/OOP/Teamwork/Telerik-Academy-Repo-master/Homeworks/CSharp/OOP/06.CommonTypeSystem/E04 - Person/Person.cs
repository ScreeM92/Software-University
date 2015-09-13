using System;

class Person
{
    //Fields
    private string name;
    private string age;

    //Properies
    public string Name
    {
        private set
        {
            this.name = value;
        }
        get { return this.name; }
    }

    public string Age
    {
        set
        {  
            if (value.CompareTo("0") < 0)
            {
                throw new ArgumentOutOfRangeException("Age must be positive!");
            }
            if (value.Equals("0"))
            {
                value = null;
            }

            this.age = value;
        }
        get { return this.age; }
    }

    //Constructors
        //empty
    public Person() { }
        //take only name
    public Person(string name) : this(name, 0) { }
        //take all information
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age.ToString();
    }

    //Override ToString() to print the info
    public override string ToString()
    {
        return string.Format("Name: {0}\nAge: {1}", this.name, this.age ?? "Unspecified");
    }
}
