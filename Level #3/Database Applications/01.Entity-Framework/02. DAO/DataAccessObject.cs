namespace DbContext
{
    using System.Data.Entity;
    using System.Linq;

    public class DataAccessObject
    {
        public static string Add(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();

            return "Employee added";
            }
        }

        public static Employee FindByKey(object key)
        {
            using (var context = new SoftUniEntities())
            {
                var employee = context.Employees.Find(key);

                return employee;
            }
        }

        public static string Modify(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                var original = context.Employees.Find(employee.EmployeeID);
                context.Entry(original).CurrentValues.SetValues(employee);
                context.SaveChanges();

                return "Employee modified";
            }
        }

        public static string Delete(Employee employee)
        {
           using (var context = new SoftUniEntities())
            {
                //var itemToRemove = context.Employees.SingleOrDefault(e => e.EmployeeID == employee.EmployeeID);

                context.Entry(employee).State = EntityState.Deleted;
                context.SaveChanges();
//
//                if (itemToRemove != null)
//                {
//                    context.Employees.Remove(itemToRemove);
//                    context.SaveChanges();

                    return "Employee deleted";
                //}

                return "Delete failed!";  
            }
        }
    }
}