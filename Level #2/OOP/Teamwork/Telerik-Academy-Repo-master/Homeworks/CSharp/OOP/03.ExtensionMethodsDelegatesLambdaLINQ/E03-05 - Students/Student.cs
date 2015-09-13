using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student
{
    private string firstName;
    private string lastName;
    private int age;

    //Constructors
    public Student(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    //Properties
    public string FirstName
    {
        set
        {
            this.firstName = value;
        }
        get
        {
            return this.firstName;
        }
    }

    public string LastName
    {
        set
        {
            this.lastName = value;
        }
        get
        {
            return this.lastName;
        }
    }

    public int Age
    {
        set
        {
            this.age = value;
        }
        get
        {
            return this.age;
        }
    }

    //Methods
    //Gets students whose first name is before its last alphabetically
    public static void GetFirstNamesWhichBeforeLastAlphabetically(Student[] students)
    {
        var studentsFinded =
            from student in students
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;

        foreach (var student in studentsFinded)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }

    //Gets all students whom are in the range 18 24 years old
    public static void GetStudentsBetween18And24(Student[] students)
    {
        var studentsFinded =
            from student in students
            where student.Age >= 18 && student.Age <= 24
            select student;

        foreach (var student in studentsFinded)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }

    //Gets all students ordered by first name, than by last name - using Lambda Expression
    public static void OrderStudentsByFullNameLambda(Student[] students)
    {
        var orderedStudents = 
            students.OrderByDescending(student => student.FirstName).ThenBy(student => student.LastName);

        foreach (var student in orderedStudents)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }

    //Gets all students ordered by first name, than by last name - using Linq
    public static void OrderStudentsByFullNameLinq(Student[] students)
    {
        var orderedStudents =
            from student in students
            orderby student.firstName descending, student.lastName descending
            select student;

        foreach (var student in orderedStudents)
        {
            Console.WriteLine(student.firstName + " " + student.lastName);
        }
    }
}
