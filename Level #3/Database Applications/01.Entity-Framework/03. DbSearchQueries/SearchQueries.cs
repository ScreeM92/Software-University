namespace _03.DbSearchQueries
{
    using System;
    using System.Linq;
    using DbContext;

    public class SearchQueries
    {
        public static void Main()
        {
            /* Increase your Console Screen Buffer Size to see the whole output from:
             * Console / Properties / Layout / Screen Buffer Size Height : 2000
             */

            Console.WriteLine("***** Task 1 *****");
            ProjectsByStartYearRange(2001, 2003);

            Console.WriteLine("\n***** Task 2 *****");
            AddressesByEmployeesCount();

            Console.WriteLine("\n***** Task 3 *****");
            EmployeeByIdWithProjects(147);

            Console.WriteLine("\n***** Task 4 *****");
            DepartmentsByEmployeesMinCount(5);                        
        }

        public static void ProjectsByStartYearRange(int startYearLowerRange, int startYearUpperRange)
        {
            var context = new SoftUniEntities();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Manager = e.Employee1.FirstName,
                    e.Projects
                })
                .Where(e => e.Projects.Any(p => p.StartDate.Year >= startYearLowerRange && p.StartDate.Year <= startYearUpperRange))
                .OrderBy(e => e.FirstName);

            foreach (var e in employees)
            {
                Console.WriteLine(new string('*', 60));
                Console.WriteLine("{0} {1} (Maneger: {2})\nProjects:", e.FirstName, e.LastName, e.Manager);

                foreach (var p in e.Projects)
                {
                    Console.WriteLine("   {0} - {1} : {2}",
                        p.Name,
                        p.StartDate.ToString("dd-MM-yyyy"),
                        p.EndDate.HasValue ? p.EndDate.Value.ToString("dd-MM-yyyy") : "not finished");
                }
            }    
        }

        public static void AddressesByEmployeesCount()
        {
            var context = new SoftUniEntities();

            var addresses = context.Addresses
                .Select(a => new { 
                    Address = a.AddressText,
                    Town = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.Town)
                .Take(10);

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees",
                    address.Address,
                    address.Town,
                    address.EmployeeCount);
            }
        }

        public static void EmployeeByIdWithProjects(int id)
        {
            var context = new SoftUniEntities();

            var employee = context.Employees
                .Where(e => e.EmployeeID == id)
                .Select(e => new {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.Projects.OrderBy(p => p.Name).Select(p => p.Name)
                });

            foreach (var emp in employee)
            {
                Console.WriteLine("Employee: {0} {1}{4}Job title: {2}{4}Projects: {3}", 
                    emp.FirstName, 
                    emp.LastName,
                    emp.JobTitle,
                    string.Join(", ", emp.Projects),
                    Environment.NewLine);
            }
        }

        public static void DepartmentsByEmployeesMinCount(int minCount)
        {
            var context = new SoftUniEntities();

            var departments = context.Departments
                .Where(d => d.Employees.Count() > minCount)
                .OrderBy(d => d.Employees.Count())
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Employee.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.HireDate,
                        e.JobTitle
                    })
                });

            Console.WriteLine(departments.Count());

            foreach (var department in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                    department.DepartmentName,
                    department.ManagerName,
                    department.Employees.Count());
            }
        }
    }
}