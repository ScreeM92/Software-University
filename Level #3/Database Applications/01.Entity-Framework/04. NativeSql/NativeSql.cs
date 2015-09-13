namespace _04.NativeSql
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using DbContext;

    class NativeSql
    {
        public static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            PrintNamesWithNativeQuery(2002);
            var native = sw.Elapsed;
            sw.Restart();
            PrintNamesWithLinqQuery(2002);
            var linq = sw.Elapsed;
            sw.Stop();

            Console.WriteLine("{0}Native: {1}{0}Linq: {2}", Environment.NewLine, native, linq);
        }

        public static void PrintNamesWithNativeQuery(int year)
        {
            var context = new SoftUniEntities();

            const string query = @"SELECT
                            e.FirstName
                        FROM Employees AS e
                        JOIN EmployeesProjects AS ep
                            ON e.EmployeeID = ep.EmployeeID
                        JOIN Projects AS p
                            ON ep.ProjectID = p.ProjectID
                        WHERE YEAR(p.StartDate) = {0}
                        GROUP BY e.FirstName
                        HAVING COUNT(p.ProjectID) > 0
                        ORDER BY e.FirstName";

            var employees = context.Database.SqlQuery<string>(query, year);

            Console.WriteLine("Navite count: {0}", employees.Count());
            //Console.WriteLine(string.Join("\n", employees));
        }

        public static void PrintNamesWithLinqQuery(int year)
        {
            var context = new SoftUniEntities();

            var employees = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == year))
                .OrderBy(e => e.FirstName)
                .Select(e => e.FirstName)
                .Distinct();

            Console.WriteLine("Linq count: {0}", employees.Count());
            //Console.WriteLine(string.Join("\n", employees));
        }
    }
}
