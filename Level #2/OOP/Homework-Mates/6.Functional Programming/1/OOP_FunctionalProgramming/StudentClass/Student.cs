using System;
using System.Collections.Generic;

class Student
{
    //FirstName, LastName, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber
    private string firstName;
    private string lastName;
    private string facultyNumber;
    private string phone;
    private string email;
    private IList<int> marks;
    private int groupNumber;

    public Student(string firstname, string lastname, string facultynumber, string phone, string email, IList<int> marks, int groupnumber)
    {
        this.FirstName = firstname;
        this.LastName = lastname;
        this.FacultyNumber = facultynumber;
        this.Phone = phone;
        this.Email = email;
        this.Marks = marks;
        this.GroupNumber = groupnumber;
    }


    //public string GroupName
    //{
    //    get
    //    {
    //        return this.groupName;
    //    }

    //    set
    //    {
    //        if (string.IsNullOrEmpty(value))
    //        {
    //            throw new ArgumentNullException("GroupName", "GroupName can not be null or empty!");
    //        }

    //        this.groupName = value;
    //    }
    //}

    public IList<int> Marks
    {
        get
        {
            return this.marks;
        }

        set
        {
            if (null == value)
            {
                throw new ArgumentNullException("Marks", "Marks list can not be null!");
            }

            this.marks = value;
        }
    }

    public int GroupNumber
    {
        get
        {
            return this.groupNumber;
        }

        set
        {
            this.groupNumber = value;
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Email", "Email can not be null or empty!");
            }

            this.email = value;
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
            this.phone = value;
        }
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("FacultyNumber", "Faculty Number can not be null or empty!");
            }

            this.facultyNumber = value;
        }
    }

    //public int Age
    //{
    //    get
    //    {
    //        return this.age;
    //    }

    //    set
    //    {
    //        if (value < 0)
    //        {
    //            throw new ArgumentException("Age can not be negative!");
    //        }

    //        this.age = value;
    //    }
    //}

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("LastName", "Last Name can not be null or empty!");
            }

            this.lastName = value;
        }
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("FirstName", "First Name can not be null or empty!");
            }

            this.firstName = value;
        }
    }

    public override string ToString()
    {
        string allMarks = string.Join(", ", this.Marks as IEnumerable<int>);
        return  string.Format("Firstname: {0}; Lastname: {1}; Faculty number: {2}, Phone: {3}, Email: {4}, Marks: {5}, Group number: {6}", this.FirstName, this.LastName, this.FacultyNumber, this.Phone, this.Email, allMarks, this.GroupNumber);
    }
    //FirstName, LastName, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber
}