using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public static class StudentQueries
    {
        public static void PrintGroup(this IEnumerable<Student> students, int groupNumber)
        {
            var group = from student in students
                where student.GroupNumber == groupNumber
                orderby student.FirstName
                select student;
            foreach (var student in group)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintByNames(this IEnumerable<Student> students)
        {
            var firstBeforeLast =
                from student in students
                where
                    System.String.Compare(student.FirstName, student.LastName,
                        System.StringComparison.CurrentCultureIgnoreCase) < 0
                orderby student.FirstName
                select student;
            foreach (var student in firstBeforeLast)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintMarksByAge(this IEnumerable<Student> students, int minAge, int maxAge)
        {
            var youngStudents =
                from student in students
                where (student.Age >= minAge) && (student.Age <= maxAge)
                select new
                {
                    student.FirstName,
                    student.LastName,
                    student.Age
                };
            foreach (var student in youngStudents)
            {
                Console.WriteLine(
                    "{0} {1}, {2}",
                    student.FirstName,
                    student.LastName,
                    student.Age
                    );
            }
        }

        public static void PrintAlphabetically(this IEnumerable<Student> students)
        {
            var sortedStudents = students.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintAlphabeticallyLinq(this IEnumerable<Student> students)
        {
            var sortedStudentsByLinq =
                from student in students
                orderby student.FirstName, student.LastName
                select student;
            foreach (var student in sortedStudentsByLinq)
            {
                Console.WriteLine(student);
            }
        }

        public static void EmailsEndingWith(this IEnumerable<Student> students, string end)
        {
            var emails =
                from student in students
                where student.Email.EndsWith(end, StringComparison.CurrentCultureIgnoreCase)
                orderby student.FirstName, student.LastName
                select student;
            foreach (var student in emails)
            {
                Console.WriteLine(student);
            }
        }

        public static void PhonesStartingWith(this IEnumerable<Student> students, IEnumerable<String> phoneStarts)
        {
            var phones =
                students.Where(student => phoneStarts.Any(phoneStart => student.Phone.StartsWith(phoneStart)))
                    .Select(student => student);
            foreach (var student in phones)
            {
                Console.WriteLine(student);
            }
        }

        public static void HasMark(this IEnumerable<Student> students, int mark)
        {
            var selectedByMark =
                from student in students
                where student.Marks.Contains(mark)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };
            foreach (var student in selectedByMark)
            {
                Console.WriteLine("{0} - {1}", student.FullName, string.Join(", ", student.Marks));
            }
        }

        public static void HasExactNumberMarks(this IEnumerable<Student> students, int mark, int count)
        {
            var selectedStudents = students
                .Where(student => (student.Marks.Count(x => x == mark) == count))
                .Select(student => student);
            foreach (var student in selectedStudents)
            {
                Console.WriteLine(student);
            }
        }

        public static void EnrolledInYear(this IEnumerable<Student> students, string year, int startIndexInFN = 4)
        {
            var selectedMarks =
                students.Where(student => student.FacultyNumber.Substring(startIndexInFN, year.Length).Equals(year))
                    .Select(student => student.Marks);
            foreach (var marks in selectedMarks)
            {
                Console.WriteLine(string.Join(", ", marks));
            }
        }
    }
}