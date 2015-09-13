using System;
using System.Linq;

class TestClass
{
    static void Main()
    {
        Student[] students = new Student[]{
            new Student("Asen", "Ivanov", 18),
            new Student("Petyr", "Petrov", 22),
            new Student("Boyan", "Goshovski", 27),
            new Student("Boyan", "Asenov", 27),
            new Student("Ioana", "Stefanova", 39),
            new Student("Jenq", "Pavlova", 15),
            new Student("Penka", "Andonova", 23)
        };

        Student.GetFirstNamesWhichBeforeLastAlphabetically(students);
        Console.WriteLine();

        Student.GetStudentsBetween18And24(students);
        Console.WriteLine();

        Student.OrderStudentsByFullNameLambda(students);
        Console.WriteLine();

        Student.OrderStudentsByFullNameLinq(students);
    }
}

