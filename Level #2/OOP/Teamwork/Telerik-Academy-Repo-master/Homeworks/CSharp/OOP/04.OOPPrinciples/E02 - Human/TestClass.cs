using System;
using System.Linq;
    
class TestClass
{
    static void Main()
    {
        Student[] students = new Student[10]
        {
            new Student("Martin", "Georgiev", 6),
            new Student("Ivan", "Petrov", 5),
            new Student("Pavel", "Kolev", 4),
            new Student("Svetlin", "Nakov", 2),
            new Student("Stefka", "Georgieva", 4),
            new Student("Nikolai", "Kostov", 6),
            new Student("Ina", "Dobrilova", 6),
            new Student("Johnny", "Bravo", 3),
            new Student("Iva", "Dragomirova", 2),
            new Student("Izabela", "Dimitrova", 5)
        };

        var orderedStudents = students.OrderBy(student => student.Grade); 
            //from student in students
            //orderby student.Grade ascending
            //select student;
        
        Console.WriteLine(students[0].GetName());
        Console.WriteLine();

        Worker[] workers = new Worker[10]
        {
            new Worker(250, 8, "Petyr", "Georgiev"),
            new Worker(300, 8, "Martin", "Ivanov"),
            new Worker(200, 6, "Dimityr", "Berbatov"),
            new Worker(600, 4, "Santa", "Claus"),
            new Worker(250, 12, "Bai", "Ivan"),
            new Worker(280, 16, "Mariq", "Pavlova"),
            new Worker(310, 8, "Metodi", "Vladigerov"),
            new Worker(420, 10, "Valentin", "Donchov"),
            new Worker(380, 8, "Kiril", "Minkov"),
            new Worker(250, 6, "Danail", "Yovchev")
        };

        var orderedWorkers = //workers.OrderBy(worker => worker.MoneyPerHour());
            from worker in workers
            orderby worker.MoneyPerHour() descending
            select worker;

        var merged = orderedStudents.Concat<Human>(orderedWorkers);
        merged =
            from item in merged
            orderby item.FirstName ascending, item.LastName
            select item;

        foreach (var item in merged)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }

    }
}
