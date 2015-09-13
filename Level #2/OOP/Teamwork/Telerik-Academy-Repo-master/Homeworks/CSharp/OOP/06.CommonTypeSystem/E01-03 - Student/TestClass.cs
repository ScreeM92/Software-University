using System;

class TestClass
{
    static void Main(string[] args)
    {
        //Creating students
        Student firstStudent = new Student("Petyr", "Georgiev", "Petrov", "example@gmail.com", 234871231, 0897213521, Universities.TechnicalUniversity, Faculties.Architecture, Specialties.Physics);
        Student secondStudent = new Student("Georgi", "'Joro'", "Georgiev", "secondExample@gmail.com", 742711495, 0897211221, Universities.Harvard, Faculties.IT, Specialties.Programming);
        Student thirdStudent = new Student("Georgi", "'Joro'", "Georgiev", "secondExample@gmail.com", 342411495, 0883393549, Universities.Harvard, Faculties.IT, Specialties.Programming);
        Student fourthStudent = new Student("Veselin", "Petrov", "Kirilov", 213312983);
        Student fifthStudent = new Student("Veselin", "Petrov", "Kirilov", 213312983);

        //Call the overriden ToString() on the first student
        Console.WriteLine(firstStudent.ToString());
        //Call the overriden ToString() on the fourth student
        Console.WriteLine(fourthStudent.ToString());

        //Checks if the second and third students are equal and print the rezult
        string areEqual = null;
        if (!secondStudent.Equals(thirdStudent))
        {
            areEqual = " NOT";
        }
        Console.WriteLine("The second and the third students are{0} the same!", areEqual);
        
        //Checks if last two students equals
        if (fourthStudent.Equals(fifthStudent))
        {
            Console.WriteLine("Students four and five are the same student");
            Console.WriteLine();
        }

        //Get the hash code of the first student
        Console.WriteLine("The hash code of {0}: {1}", firstStudent.FirstName, firstStudent.GetHashCode());
        Console.WriteLine();

        //Check if equals with the == operator
        if (fifthStudent == fourthStudent)
        {
            Console.WriteLine("Students four and five are the same student");
        }

        //Check if not equals ( != operator)
        if (firstStudent != thirdStudent)
        {
            Console.WriteLine("Students one and three are different");
            Console.WriteLine();
        }

        //Clone the first student (deep clone)
        Student sixthStudent = firstStudent.Clone();
        Console.WriteLine(sixthStudent.ToString());

        //Compare students
        if (firstStudent.CompareTo(sixthStudent) == 0)
        {
            Console.WriteLine("Student one is equal to student six");
            Console.WriteLine();
        }

        if (secondStudent.CompareTo(fourthStudent) < 0)
        {
            Console.WriteLine(secondStudent.FirstName);
            Console.WriteLine(fourthStudent.FirstName);
            Console.WriteLine("Student four is before student two");
        }
    }
}