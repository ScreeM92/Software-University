using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_12_Students
{
    class StudentTest
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Vladi", "Delchev", 25, 123458, "+359 896 325410", "vlado@abv.bg", 2, 5, 4, 3, 2));
            students.Add(new Student("Elena", "Gancheva", 21, 123514, "+359 896 362031", "elena@gmail.com", 1, 2, 4, 5, 2));
            students.Add(new Student("Slav", "Georgiev", 20, 143056, "+359 2 203145", "slav@gmail.com", 7, 6, 4, 3, 6));
            students.Add(new Student("Evgeni", "Borisov", 30, 963414, "+359 896 029674", "evgeni@gmail.com", 2, 5, 4, 3, 6));
            students.Add(new Student("Emiliya", "Petrova", 17, 523414, "02 756130", "emi@abv.bg", 4, 5, 3, 3, 2));

            var queryGroup2 =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Console.WriteLine("Group 2: ");
            foreach (var student in queryGroup2)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var queryName =
                from student in students
                where String.Compare(student.FirstName, student.LastName) < 0
                select student;

            Console.WriteLine("Compared names: ");
            foreach (var student in queryName)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine();

            var queryAge =
                from student in students
                where (student.Age > 17 && student.Age < 25)
                select student;

            Console.WriteLine("Students between the age 18 and the age 24:");
            foreach (var student in queryAge)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + "\nage: " + student.Age);
            }
            Console.WriteLine();

            var studentsByNameDescending = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName)
                .Select(s => new { FirstName = s.FirstName, LastName = s.LastName });

            Console.WriteLine("Student names in descending order: ");
            foreach (var student in studentsByNameDescending)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine();

            var queryEmail =
                from student in students
                where student.Email.Contains("@abv.bg")
                select student;

            Console.WriteLine("Students with email in www.abv.bg:");
            foreach (var student in queryEmail)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " -> email: " + student.Email);
            }
            Console.WriteLine();

            var queryPhoneCode =
                from student in students
                where (student.Phone.Contains("02 ") || student.Phone.Contains("+359 2 "))
                select student;

            Console.WriteLine("Students who live in Sofia: ");
            foreach (var student in queryPhoneCode)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var queryMarks6 =
                from student in students
                where student.Marks.Contains(6)
                select student;

            Console.WriteLine("Student with at least one 6 in marks:");
            foreach (var student in queryMarks6)
            {
                var marksString = Student.ConvertMarks(student.Marks);
                Console.WriteLine(student.FirstName + " " + student.LastName + " -> Excellent(6)\nAll marks: " + marksString);
            }
            Console.WriteLine();

            var queryMarks2 =
               from student in students
               where student.Marks.Contains(2)
               select student;

            Console.WriteLine("Student with at least one 6 in marks:");
            foreach (var student in queryMarks2)
            {
                var marksString = Student.ConvertMarks(student.Marks);
                Console.WriteLine(student.FirstName + " " + student.LastName + " -> Poor(2)\nAll marks: " + marksString);
            }
            Console.WriteLine();

            var enrolled2014 = students.FindAll(s => s.FacultyNumber.ToString().EndsWith("14"));

            Console.WriteLine("The marks of students enrolled 2014:");
            foreach (var student in enrolled2014)
            {
                var marksString = Student.ConvertMarks(student.Marks);
                Console.WriteLine("Faculty number: " + student.FacultyNumber + " -> marks: " + marksString);
            }
        }
    }
}
