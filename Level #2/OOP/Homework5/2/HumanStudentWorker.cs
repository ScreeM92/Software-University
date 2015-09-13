using System;
using System.Collections.Generic;
using System.Linq;

class HumanStudentWorker
{
    static void Main()
    {
        //IList<Student> students = new List<Student>
        //{
        //    new Student("Peter", "Brown", "abc10005"),
        //    new Student("Milka", "Ivanova", "vde12346"),
        //    new Student("Todor", "Geshov", "cwe12347"),
        //    new Student("Vasil", "Angelov", "abc10001"),
        //    new Student("Mihail", "Petrov", "nht10200"),
        //    new Student("Todor", "Genchev", "nth12346"),
        //    new Student("Ana", "Mihailova", "ggg12346"),
        //    new Student("Aneta", "Ivanova", "rrr12346"),
        //    new Student("Angel", "Georgiev", "abc12346"),
        //    new Student("Boris", "Borisov", "abc10000"),
        //};

        //IList<Worker> workers = new List<Worker>
        //{
        //    new Worker("Petera", "Brown", 250, 8),
        //    new Worker("Milkaa", "Ivanova", 250, 8),
        //    new Worker("Todora", "Geshov", 200, 8),
        //    new Worker("Vasila", "Angelov", 200, 6),
        //    new Worker("Mihaila", "Petrov", 350, 8),
        //    new Worker("Todora", "Genchev", 150, 6),
        //    new Worker("Ana", "Nikolova", 150, 8),
        //    new Worker("Anita", "Ivanova", 500, 4),
        //    new Worker("Angela", "Georgiev", 300, 8),
        //    new Worker("Boris", "Asenov", 320,8 ),
        //};

        //var sortedStudentByFacultyNumber = students.OrderBy(s => s.FacultyNumber);
        //Console.WriteLine(string.Join("\n", sortedStudentByFacultyNumber.Select(s => s.ToString())));
        //Console.WriteLine();

        //var sortedWorkerByPaymentPerHour = workers.OrderByDescending(w => w.MoneyPerHour());
        //Console.WriteLine(string.Join("\n", sortedWorkerByPaymentPerHour.Select(w => w.ToString())));
        //Console.WriteLine();

        //var humans = new List<Human>();
        //humans.AddRange(students);
        //humans.AddRange(workers);
        //var sortHumansByNames = humans
        //    .OrderBy(h => h.FirstName)
        //    .ThenBy(h => h.LastName)
        //    .Select(h => h.FirstName + " " + h.LastName + " - " + h.GetType());

        //Console.WriteLine(string.Join("\n", sortHumansByNames));


        IList<Student> students = new List<Student>
        {
            new Student("Mihail", "Nikov", "w55555"),
            new Student("Mitko", "Paunov", "w512sd33"),
            new Student("Dacnho", "Nikov", "555w5"),
            new Student("Doncho", "Raunov", "51s33"),
            new Student("Bivol", "Kikov", "a555d55"),
            new Student("Levent", "Jaunov", "5a1s233"),
            new Student("Georgi", "Pikov", "r555f55"),
            new Student("Asen", "Aunov", "5s1da233"),
            new Student("Hristo", "Rikov", "ss55d555"),
            new Student("Asen", "Kaunov", "51as233")
        };

        IList<Worker> workers = new List<Worker>
        {
            new Worker("Pisho", "Goshev", 1000, 4),
            new Worker("Gisho", "Roshev", 2000, 1),
            new Worker("Kisho", "Aoshev", 3000, 8),
            new Worker("Risho", "Coshev", 4000, 3),
            new Worker("Misho", "Voshev", 1200, 2),
            new Worker("Eisho", "Qoshev", 1300, 1),
            new Worker("Zisho", "Toshev", 1400, 4),
            new Worker("Pisho", "Poshev", 2200, 8),
            new Worker("Eisho", "Toshev", 3300, 8),
            new Worker("Visho", "Boshev", 4440, 10)
        };

        var sortedStudentByFacultetyNumber = students.OrderBy(s => s.FacultyNumber);

        Console.WriteLine(string.Join("\n", sortedStudentByFacultetyNumber));
        Console.WriteLine();

        var sortedWorkersByPaymentPerHours = workers.OrderByDescending(w => w.MoneyPerHour());

        Console.WriteLine(string.Join("\n", sortedWorkersByPaymentPerHours));
        Console.WriteLine();

        var human = new List<Human>();

        human.AddRange(students);
        human.AddRange(workers);

        var sortedHuman = human.OrderBy(h => h.FirstName)
            .ThenBy(h => h.LastName);

        Console.WriteLine(string.Join("\n", sortedHuman));
    }
}