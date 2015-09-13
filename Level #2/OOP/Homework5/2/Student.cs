using System.Threading;

public class Student : Human
{
    //private string facultyNumber;

    //public Student(string firstName, string lastName, string facultyNumber)
    //    : base(firstName, lastName)
    //{
    //    this.FacultyNumber = facultyNumber;
    //}

    //public string FacultyNumber
    //{
    //    get { return facultyNumber; }

    //    set
    //    {
    //        Validation.ChekForValidFacultyNumber(value, "facultyNumber");
    //        this.facultyNumber = value;
    //    }
    //}

    //public override string ToString()
    //{
    //    return base.ToString() + " - " + this.FacultyNumber;
    //}


    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        set
        {
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + ", F:" + this.FacultyNumber;
    }
}