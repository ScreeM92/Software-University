using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class StudentDemo
    {
        public static void Main()
        {
            var students = new[]{
                new Student(
                    "Petar", 
                    "Peshev", 
                    23, 
                    "10111400", 
                    "02/943-48-06", 
                    "pesho_picha@abv.bg", 
                    new List<int>() 
                        { 2, 5, 5, 6, 6, 6, 6 }, 
                    2),
                new Student(
                    "Georgi", 
                    "Goshev", 
                    19, 
                    "13111495", 
                    "+359887894568",
                    "gosho.goshev@gmail.com", 
                    new List<int>() { 2, 2, 2, 2, 2, 3, 4 }, 
                    1
                    ),
                new Student(
                    "Stoqn", 
                    "Toshev", 
                    56, 
                    "10111234", 
                    "+359279542357",
                    "stoqncho@abv.bg", 
                    new List<int>() { 6, 6, 6, 6, 6, 6, 6 }, 
                    3
                    ),
                new Student(
                    "Acho", 
                    "Stoqnov", 
                    20, 
                    "12119874", 
                    "+359987456987",
                    "achkata@abv.bg", 
                    new List<int>() { 6, 6, 4, 6, 4, 2, 3 }, 
                    2
                    ),
                new Student(
                    "Acho", 
                    "Angelov", 
                    18, 
                    "14124568", 
                    "+359789654123",
                    "angelcho@gmail.com", 
                    new List<int>() { 5, 2, 4, 6, 4, 2, 3 }, 
                    1
                    )
            };

            students.PrintGroup(2);
            Console.WriteLine();

            students.PrintByNames();
            Console.WriteLine();

            students.PrintMarksByAge(18, 24);
            Console.WriteLine();

            students.PrintAlphabetically();
            Console.WriteLine();

            students.PrintAlphabeticallyLinq();
            Console.WriteLine();

            students.EmailsEndingWith("abv.bg");
            Console.WriteLine();

            students.PhonesStartingWith(new[]{"02", "+3592", "+359 2"});
            Console.WriteLine();

            students.HasMark(6);
            Console.WriteLine();

            students.HasExactNumberMarks(2, 2);
            Console.WriteLine();

            students.EnrolledInYear("14");
        }
    }
}
