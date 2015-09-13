using System;
using System.Collections.Generic;

class TestClass
{    
    static void Main()
    {
        Teacher firstTeacher = new Teacher("Doncho");
        Teacher secondTeacher = new Teacher("Nakov");
        Teacher thirdTeacher = new Teacher("Joro");
        Teacher fourthTeacher = new Teacher("Misho");

        firstTeacher.AddDiscipline("HTML", 6, 7);
        secondTeacher.AddDiscipline("CSharp", 6, 7);
        thirdTeacher.AddDiscipline("CSharp", 6, 7);
        fourthTeacher.AddDiscipline("HTML", 6, 7);

        List<Teacher> teachersTeam = new List<Teacher>()
        {
            firstTeacher,
            secondTeacher,
            thirdTeacher,
            fourthTeacher
        };


        Class firstClass = new Class(teachersTeam, "First class");
        Class secondClass = new Class(teachersTeam, "Second class");
        

        School testSchool = new School();
        testSchool.AddStudent("Ivo", 3423);
        testSchool.AddClass(firstClass);
        testSchool.AddClass(secondClass);

        Console.WriteLine("First student class number: {0}", testSchool.Students[0].ClassNumber);
        Console.WriteLine("First student name: {0}", testSchool.Students[0].Name);

        Console.WriteLine("Class Id: {0}", testSchool.Classes[0].TextId);
        Console.WriteLine("Second class, third teacher name: {0}", testSchool.Classes[1].Teachers[2].Name);

        testSchool.Students[0].Comment = "Cool";

        Console.WriteLine("Comment for {0}: {1}", testSchool.Students[0].Name, testSchool.Students[0].Comment);
    }
}