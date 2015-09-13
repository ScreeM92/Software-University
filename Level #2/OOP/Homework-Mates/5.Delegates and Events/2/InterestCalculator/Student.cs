using System;

class Student
{
    private int age;

    public string Name { get; set; }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new FormatException("Age can't be negative!");
            }
            age = value;
        }
    }

    public event EventHandler PropertyChanged;

}

