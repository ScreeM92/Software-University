using System;
using System.Text;

class Student : ICloneable, IComparable<Student>
{
    //Fields
        //string
    private string firstName;
    private string middleName;
    private string lastName;
    private string emailAddress;
    private Universities university;
    private Faculties faculty;
    private Specialties specialty;

        //int
    private int ssn;
    private int mobilePhone;

    //Properties
        //string
    public string FirstName
    {
        private set { this.firstName = value; }
        get { return this.firstName; }
    }
    public string MiddleName
    {
        private set { this.middleName = value; }
        get { return this.middleName; }
    }
    public string LastName
    {
        private set { this.lastName = value; }
        get { return this.lastName; }
    }
    public string EmailAddress
    {
        private set { this.emailAddress = value; }
        get { return this.emailAddress; }
    }

        //enum
    public Universities University
    {
        private set { this.university = value; }
        get { return this.university; }
    }
    public Faculties Faculty
    {
        private set { this.faculty = value; }
        get { return this.faculty; }
    }
    public Specialties Specialty
    {
        private set { this.specialty = value; }
        get { return this.specialty; }
    }
        
        //int
    public int SSN
    {
        private set { this.ssn = value; }
        get { return this.ssn; }
    }
    public int MobilePhone
    {
        private set { this.mobilePhone = value; }
        get { return this.mobilePhone; }
    }

    //Constructors
        //empty
    public Student() { }

        //takes names only
    public Student(string firstName, string middleName, string lastName, int ssn)
        : this(firstName, middleName, lastName, "Not specified", ssn, 000000000 , Universities.Undefined, Faculties.Undefined, Specialties.Undefined)
    {
    }
    
        //takes all the information
    public Student(string firstName, string middleName, string lastName, string emailAddress, int ssn, int mobile,  
        Universities university, Faculties faculty, Specialties specialty)
    {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.emailAddress = emailAddress;
        this.ssn = ssn;
        this.mobilePhone = mobile;
        this.university = university;
        this.faculty = faculty;
        this.specialty = specialty;
    }


    //Methods
        //Override ToString() to print all the info about the student
    public override string ToString()
    {
        StringBuilder toStringer = new StringBuilder();

        toStringer.AppendFormat("Name: {0} {1} {2}", firstName, this.middleName, this.lastName);
        toStringer.AppendLine();
        toStringer.AppendFormat("Social security number: {0}", this.ssn);
        toStringer.AppendLine();
        toStringer.AppendFormat("Mobile phone: {0}", this.mobilePhone);
        toStringer.AppendLine();
        toStringer.AppendFormat("Email address: {0}", this.emailAddress);
        toStringer.AppendLine();
        toStringer.AppendFormat("University: {0}", this.university);
        toStringer.AppendLine();
        toStringer.AppendFormat("Faculty: {0}", this.faculty);
        toStringer.AppendLine();
        toStringer.AppendFormat("Specialty: {0}", this.specialty);
        toStringer.AppendLine();

        return toStringer.ToString();
    }

        //Override Equals()
    public override bool Equals(object obj)
    {
        Student student = obj as Student;

        if ((object)student == null)
        {
            return false;
        }

        if (!Object.Equals(this.ssn, student.ssn))
        {
            return false;
        }

        if (!Object.Equals(this.lastName, student.lastName))
        {
            return false;
        }
        return true;
    }

        //Override GetHashCode()
    public override int GetHashCode()
    {
        return this.firstName.GetHashCode() ^ this.ssn.GetHashCode();
    }

        //Overloading the equals operator
    public static bool operator == (Student obj1, Student obj2)
    {
        return Student.Equals(obj1, obj2);
    }

        //Overloading the Not equals operator
    public static bool operator !=(Student obj1, Student obj2)
    {
        return !Student.Equals(obj1, obj2);
    }

        // Implicit interface implementation
    object ICloneable.Clone()  
    {
        return this.Clone();
    }

        //The method Clone()
    public Student Clone()
    {
        Student newStudent = new Student(this.firstName, this.middleName, this.lastName, this.emailAddress,
            this.ssn, this.mobilePhone, this.university, this.faculty, this.specialty);
        return newStudent;
    }

        //CompareTo implementation
    public int CompareTo(Student student)
    {
        if (this.firstName != student.firstName)
        {
            return string.Compare(this.firstName, student.firstName);
        }
        if (this.lastName != student.lastName)
        {
            return string.Compare(this.lastName, student.lastName);
        }
        if (this.middleName != student.middleName)
        {
            return string.Compare(this.middleName, student.middleName);
        }

        if (this.ssn != student.ssn)
        {
            return (this.ssn - student.ssn);
        }

        return 0;
    }
    
}
