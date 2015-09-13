using System;

public class Student : Human
{
    private int age;
    //private string name;
    private string phone;

    public Student(int age, string name, string phone)
        : base(name)
    {
        this.Age = age;
        this.Phone = phone;
    }

    public Student(string name)
        : this(0, name, null)
    {
    }

    public Student(int age, string name)
        : this(age, name, null)
    {
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be < 0");
            }
            this.age = value;
        }
    }

    public string Phone
    {
        get
        {
            return this.phone;
        }
        set
        {
            if (value != null)
            {
                if (value.Length < 6)
                {
                    throw new ArgumentException("...");
                }

                foreach (char symbol in value)
                {
                    if (!char.IsDigit(symbol) && symbol != ' ')
                    {
                        throw new ArgumentException("The phone must consist of digits");
                    }
                }
            }

            this.phone = value;
        }
    }

    //public override void Speak()
    //{
    //    throw new NotImplementedException();
    //}

    public override void SayName()
    {
        Console.WriteLine("In Student");
        base.SayName();
    }

    public override void Speak()
    {
        throw new NotImplementedException();
    }

    public Func<int, string> myFunc = a => (a + 5).ToString();
}