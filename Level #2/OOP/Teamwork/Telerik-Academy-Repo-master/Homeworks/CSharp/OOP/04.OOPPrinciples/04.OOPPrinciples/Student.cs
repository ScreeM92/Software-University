using System;

internal class Student : Human, ICommentable
{
    private int uniqueClassNumber;

    public string Comment { get; set; }

    public int ClassNumber 
    {
        get
        {
            return this.uniqueClassNumber;
        }
        set
        {
            if (value < 0)
            {
                throw new FormatException("Must be positive number");
            }
            this.uniqueClassNumber = value;
        }
    }

    public Student(string name, int classNumber)
        : base(name)
    {
        this.uniqueClassNumber = classNumber;
    }
}
