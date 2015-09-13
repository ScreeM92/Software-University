namespace ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.DbContext;
    using System.Data.Entity;

    class ConsoleClient
    {
        public static void Main()
        {
            Console.WriteLine("{0}\n|     Task 1 {1}|\n{0}", new string('-', 74), new string(' ', 60));
            StudentsWithTHeirHomeworks();

            Console.WriteLine("\n{0}\n|     Task 2 {1}|\n{0}", new string('-', 74), new string(' ', 60));
            CoursesWithTheirResources();

            Console.WriteLine("\n{0}\n|     Task 3 {1}|\n{0}", new string('-', 74), new string(' ', 60));
            CoursesWithResourcesGreateThen(0);

            Console.WriteLine("\n{0}\n|     Task 4 {1}|\n{0}", new string('-', 74), new string(' ', 60));
            CoursesActiveOnADate(new DateTime(2015, 3, 15));

            Console.WriteLine("\n{0}\n|     Task 5 {1}|\n{0}", new string('-', 74), new string(' ', 60));
            StudentsStaticticOfCourses();
        }

        public static void StudentsWithTHeirHomeworks()
        {
            using (var context = new StudentSystemContext())
            {
                var students = context.Students
                    .Select(s => new
                    {
                        s.Name,
                        Homeworks = s.Homeworks.Select(h => new { h.Content, h.ContentType})
                    });

                if (!students.Any())
                {
                    Console.WriteLine("No students");
                }
                else
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine("Student: {0}", student.Name);
                        foreach (var homework in student.Homeworks)
                        {
                            Console.WriteLine("Homework content: {0}; Type: {1}", homework.Content, homework.ContentType);
                        }
                        Console.WriteLine(new string('-', 40));
                    }
                }
            }
        }

        public static void CoursesWithTheirResources()
        {
            using (var context = new StudentSystemContext())
            {
                var courses = context.Courses
                    .OrderBy(s => s.StartDate)
                    .ThenByDescending(s => s.EndDate)
                    .Select(s => new 
                    { 
                        s.Name,
                        s.Description,
                        s.Resources
                    });

                if (!courses.Any())
                {
                    Console.WriteLine("No courses");
                }
                else
                {
                    foreach (var course in courses)
                    {
                        Console.WriteLine("Course: {0}, Description: {1}", course.Name, course.Description);
                        foreach (var resource in course.Resources)
                        {
                            Console.WriteLine("Resource name: {0}; Type: {1}; Url: {2}",
                                resource.Name,
                                resource.ResourceType,
                                resource.Url);
                        }

                        Console.WriteLine(new string('-', 40));
                    }
                }                
            }
        }

        public static void CoursesWithResourcesGreateThen(int minResources)
        {
            using (var context = new StudentSystemContext())
            {
                var courses = context.Courses
                    .Where(c => c.Resources.Count > minResources)
                    .OrderByDescending(c => c.Resources.Count)
                    .ThenByDescending(c => c.StartDate)
                    .Select(c => new
                    {
                        c.Name,
                        ResourcesCount = c.Resources.Count
                    });

                if (!courses.Any())
                {
                    Console.WriteLine("No courses");
                }
                else
                {
                    foreach (var course in courses)
                    {
                        Console.WriteLine("Course: {0} - {1} resources", course.Name, course.ResourcesCount);
                    }
                }
            }
        }

        public static void CoursesActiveOnADate(DateTime date)
        {
            using (var context = new StudentSystemContext())
            {
                var courses = context.Courses
                    .Where(c => DbFunctions.TruncateTime(c.StartDate) <= date && DbFunctions.TruncateTime(c.EndDate) >= date)
                    .OrderByDescending(c => c.Students.Count)
                    .ThenByDescending(c => DbFunctions.DiffDays(c.StartDate, c.EndDate))                    
                    .Select(c => new 
                    {
                        c.Name,
                        c.StartDate,
                        c.EndDate,
                        Duration = DbFunctions.DiffDays(c.StartDate, c.EndDate),
                        StudentsCount = c.Students.Count
                    });

                foreach (var course in courses)
                {
                    Console.WriteLine("Course: {0}; Active: {1} - {2}; Duration: {3} days", 
                        course.Name, 
                        course.StartDate.ToString("dd-MM-yyyy"),
                        course.EndDate.Date.ToString("dd-MM-yyyy"),
                        course.Duration);
                }
            }
        }

        public static void StudentsStaticticOfCourses()
        {
            using (var context = new StudentSystemContext())
            {
                var students = context.Students
                    .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                    .ThenByDescending(s => s.Courses.Count)
                    .ThenBy(s => s.Name)
                    .Select(s => new
                    {
                        s.Name,
                        CoursesCount = s.Courses.Count,
                        TotalPrice = s.Courses.Sum(c => c.Price),
                        AveragePrice = s.Courses.Average(c => c.Price)
                    });

                foreach (var student in students)
                {
                    Console.WriteLine("Student: {0}, Total Courses: {1}, Total Price: {2:N2}, Average Price: {3:N2}",
                        student.Name,
                        student.CoursesCount,
                        student.TotalPrice,
                        student.AveragePrice);
                }
            }
        }
    }
}