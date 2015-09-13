using System;

class OnsiteStudent : Student
{
    private int numberOfVisits;

    public OnsiteStudent(int age, string name, string phone, int numberOfVisits)
        : base(age, name, phone)
    {
        this.NumberOfVisits = numberOfVisits;
    }

    public OnsiteStudent(string name)
        : base(name)
    {
    }

    public OnsiteStudent(int age, string name, int numberOfVisits)
        : this(age, name, null, numberOfVisits)
    {
    }

    public int NumberOfVisits
    {
        get { return this.numberOfVisits;}
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Numbers can not be smaller than 0");
            }
            this.numberOfVisits = value;
        }
    }
}

