using System;

class Student : Human
{
    private int grade;

    public int Grade
    {
        get { return this.grade; }
        set
        {
            if (value > 6 || value < 2)
            {
                throw new ArgumentOutOfRangeException("The grade must be between 2 and 6");
            }
            this.grade = value;
        }
    }

    public Student(string firstName, string lastName, int grade)
        : base(firstName, lastName)
    {
        this.Grade = grade;
    }

    public override string GetName()
    {
        return this.FirstName + " " + this.LastName;
    }
}