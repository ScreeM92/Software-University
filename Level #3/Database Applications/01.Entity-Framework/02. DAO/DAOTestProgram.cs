namespace EntryPoint
{
    using System;
    using System.Linq;
    using DbContext;

    public class DAOTestProgram
    {
        public static void Main()
        {
            var context = new SoftUniEntities();

            var newEmployee = new Employee
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                JobTitle = "Database administrator",
                DepartmentID = context.Departments
                                    .Where(d => d.Name == "Research and Development")
                                    .Select(a => a.DepartmentID)
                                    .First(),
                HireDate = DateTime.Now,
                Salary = 15000
            };

            Console.WriteLine("1. Add new employee");
            Console.WriteLine("   -- {0} with Id: {1}", DataAccessObject.Add(newEmployee), newEmployee.EmployeeID);

            Console.WriteLine("2. Find employee by key");
            var employee = DataAccessObject.FindByKey(newEmployee.EmployeeID);
            Console.WriteLine("   -- {0} {1}", employee.FirstName, employee.LastName);

            Console.WriteLine("3. Edit employee first name");
            employee.FirstName = "Todor";
            Console.WriteLine("   -- " + DataAccessObject.Modify(employee));
            Console.WriteLine("   -- New name: {0} {1}", employee.FirstName, employee.LastName);

            Console.WriteLine("4. Delete employee");
            Console.WriteLine("   -- {0}", DataAccessObject.Delete(employee));
        }
    }
}