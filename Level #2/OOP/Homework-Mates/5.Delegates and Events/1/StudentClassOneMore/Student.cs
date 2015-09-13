using System;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Student(string name, int age)
    {
        this.StudentName = name;
        this.StudentAge = age;
    }

    public event EventHandler<EventStudent<string>> handleEvent;

    public string StudentName 
    {
        get { return this.Name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    String.Format("Student name cannot be null or empty")
                );
            }
            this.IsPropChanged(new EventStudent<string>("Name", this.Name, value));
            this.Name = value;
        }
    }

    public int StudentAge
    {
        get { return this.Age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    String.Format("Student age cannot be 0 or negative")
                );
            }
            this.IsPropChanged(new EventStudent<string>("Age", this.Age.ToString(), value.ToString()));
            this.Age = value;
        }
    }

    public virtual void IsPropChanged(EventStudent<string> e)
    {
        if (null != this.handleEvent)
        {
            this.handleEvent(this, e);
        }
    }
}